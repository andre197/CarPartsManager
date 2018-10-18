namespace CarPartsManager.Logic
{
    using Helpers;
    using System.Collections.Generic;

    public interface ICarPartsSchemesService
    {
        IEntityService EntityService { get; set; }
        void AddCarPartSchemes(IEnumerable<CarPartsSchemeHelper> schemes);
        IEnumerable<CarPartsSchemeHelper> GetCarPartsSchemesByPartId(int partId);
        void DeleteScheme(CarPartsSchemeHelper scheme);
        void DeleteSchemesForPart(int partId);
    }
}
