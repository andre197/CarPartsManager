namespace CarPartsManager.Logic.Implementations
{
    using DAL;
    using Helpers;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class CarPartsService : ICarPartsService
    {
        public IEntityService EntityService { get; set; }

        public CarPartsManagerEntities Entity
        {
            get
            {
                return EntityService.GetEntities();
            }
        }

        public IEnumerable<CarMakerHelper> GetAllCarMakers()
        {
            IEnumerable<CarMakerHelper> res = Entity.CarMakers
                .Include(cm => cm.CarModels)
                .AsNoTracking()
                .AsEnumerable()
                .Select(c => new CarMakerHelper()
                {
                    Id = c.Id,
                    Models = ConvertCarModelToCarModelHelper(c.CarModels),
                    Name = c.CarMakerName
                })
                .ToList();

            return res;
        }

        public CarMaker GetCarMakerByName(string name)
        {
            return Entity.CarMakers.AsNoTracking().FirstOrDefault(cm => cm.CarMakerName == name);
        }

        public IEnumerable<CarModelHelper> GetAllModelsForMaker(string maker)
        {
            var carMaker = GetCarMakerByName(maker);
            if (carMaker == null)
            {
                return new List<CarModelHelper>();
            }
            var models = carMaker.CarModels.AsEnumerable();
            return ConvertCarModelToCarModelHelper(models);
        }

        private IEnumerable<CarModelHelper> ConvertCarModelToCarModelHelper(IEnumerable<CarModel> models)
        {
            return models.Select(c => new CarModelHelper
            {
                CreationDate = c.CreationDate.Year.ToString(),
                Id = c.Id,
                MakerId = c.CardMakerId,
                ModelName = c.ModelName
            });
        }

        public IEnumerable<CarPartsViewHelper> GetAllParts()
        {
            IEnumerable<CarPartsViewHelper> res = new List<CarPartsViewHelper>();

            res = Entity.CarParts
                .Include(cp => cp.CarModel)
                .Include(cp => cp.CarModel.CarMaker)
                .AsEnumerable()
                .Select(cp => new CarPartsViewHelper
                {
                    PartId = cp.Id,
                    ModelId = cp.CarModel.Id,
                    CreationDate = cp.CarModel.CreationDate,
                    MakerId = cp.CarModel.CarMaker.Id,
                    MakerName = cp.CarModel.CarMaker.CarMakerName,
                    Model = cp.CarModel.ModelName,
                    PartName = cp.PartName,
                    PartUniqueNumber = cp.UniqueNumber,
                    Quantity = cp.Quantity
                });

            return res;
        }

        public CarPartsViewHelper AddEditPart(CarPartsViewHelper carPartsView)
        {
            bool wasNull = false;
            var maker = Entity.CarMakers.FirstOrDefault(m => m.Id == carPartsView.MakerId || m.CarMakerName == carPartsView.MakerName);
            if (maker == null)
            {
                maker = new CarMaker()
                {
                    CarMakerName = carPartsView.MakerName
                };
                wasNull = true;
            }

            var model = Entity.CarModels.FirstOrDefault(cm => cm.Id == carPartsView.ModelId);
            if (model == null)
            {
                model = new CarModel()
                {
                    ModelName = carPartsView.Model,
                    CreationDate = carPartsView.CreationDate
                };
                if (wasNull)
                {
                    model.CarMaker = maker;
                }
                else
                {
                    model.CardMakerId = maker.Id;
                }
                wasNull = true;
            }
            else
            {
                wasNull = false;
            }

            var carPart = Entity.CarParts.FirstOrDefault(cp => cp.Id == carPartsView.PartId);
            if (carPart == null)
            {
                carPart = new CarPart()
                {
                    PartName = carPartsView.PartName,
                    Quantity = carPartsView.Quantity,
                    UniqueNumber = carPartsView.PartUniqueNumber
                };
                Entity.CarParts.Add(carPart);
            }
            else
            {
                carPart.Quantity = carPartsView.Quantity;
                carPart.PartName = carPartsView.PartName;
                carPart.UniqueNumber = carPartsView.PartUniqueNumber;
            }

            if (wasNull)
            {
                carPart.CarModel = model;
            }
            else
            {
                carPart.CarModelId = model.Id;
            }

            Entity.SaveChanges();
            carPartsView.PartId = carPart.Id;
            return carPartsView;
        }

        public void DeleteCarPartItem(CarPartsViewHelper carPartsViewHelper)
        {
            var toBeDeleted = Entity.CarParts.FirstOrDefault(cp => cp.Id == carPartsViewHelper.PartId);

            Entity.CarPartSchemes.RemoveRange(toBeDeleted.CarPartSchemes);
            Entity.CarParts.Remove(toBeDeleted);
            Entity.SaveChanges();
        }
    }
}
