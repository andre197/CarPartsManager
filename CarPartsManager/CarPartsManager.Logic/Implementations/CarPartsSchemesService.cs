namespace CarPartsManager.Logic.Implementations
{
    using DAL;
    using Helpers;
    using System.Linq;
    using System.Collections.Generic;

    public class CarPartsSchemesService : ICarPartsSchemesService
    {
        private CarPartsManagerEntities _entity;

        public IEntityService EntityService { get; set; }
        public CarPartsManagerEntities Entity
        {
            get
            {
                if (_entity == null)
                {
                    _entity = EntityService.GetEntities();
                }

                return _entity;
            }
       }

        public void AddCarPartSchemes(IEnumerable<CarPartsSchemeHelper> schemes)
        {
            foreach (var scheme in schemes)
            {
                Entity.CarPartSchemes.Add(new CarPartScheme()
                {
                    CarPartId = scheme.PartId,
                    Scheme = scheme.Scheme
                });
            }

            Entity.SaveChanges();
        }

        public void DeleteScheme(CarPartsSchemeHelper scheme)
        {
            var dbScheme = Entity.CarPartSchemes.FirstOrDefault(s => s.Id == scheme.SchemeId);
            if (dbScheme == null)
            {
                return;
            }

            Entity.CarPartSchemes.Remove(dbScheme);
            Entity.SaveChanges();
        }

        public void DeleteSchemesForPart(int partId)
        {
            var schemes = Entity.CarPartSchemes.Where(s => s.CarPartId == partId);

            Entity.CarPartSchemes.RemoveRange(schemes);
            Entity.SaveChanges();
        }

        public IEnumerable<CarPartsSchemeHelper> GetCarPartsSchemesByPartId(int partId)
        {
            var res = new List<CarPartsSchemeHelper>();
            var schemes = Entity.CarPartSchemes.AsNoTracking().Where(s => s.CarPartId == partId);
            foreach (var scheme in schemes)
            {
                res.Add(new CarPartsSchemeHelper()
                {
                    PartId = scheme.CarPartId,
                    Scheme = scheme.Scheme,
                    SchemeId = scheme.Id
                });
            }

            return res;
        }
    }
}
