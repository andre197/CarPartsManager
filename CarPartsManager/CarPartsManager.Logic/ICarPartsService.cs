namespace CarPartsManager.Logic
{
    using DAL;
    using Helpers;
    using System.Collections.Generic;

    public interface ICarPartsService
    {
        IEntityService EntityService { get; set; }
        IEnumerable<CarPartsViewHelper> GetAllParts();
        IEnumerable<CarMakerHelper> GetAllCarMakers();
        IEnumerable<CarModelHelper> GetAllModelsForMaker(string maker);
        CarMaker GetCarMakerByName(string name);
        CarPartsViewHelper AddEditPart(CarPartsViewHelper carPartsView);
        void DeleteCarPartItem(CarPartsViewHelper carPartsViewHelper);
    }
}
