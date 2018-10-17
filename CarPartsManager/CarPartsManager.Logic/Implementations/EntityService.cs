namespace CarPartsManager.Logic.Implementations
{
    using DAL;

    public class EntityService : IEntityService
    {
        private CarPartsManagerEntities entities;

        public CarPartsManagerEntities GetEntities()
        {
            if (entities == null)
            {
                entities = new CarPartsManagerEntities();
            }

            return entities;
        }
    }
}
