namespace CarPartsManager.Logic
{
    using DAL;

    public interface IEntityService
    {
        CarPartsManagerEntities GetEntities();
    }
}
