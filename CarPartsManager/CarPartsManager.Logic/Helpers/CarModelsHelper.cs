namespace CarPartsManager.Logic.Helpers
{
    public class CarModelHelper
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string CreationDate { get; set; }
        public int MakerId { get; set; }
        public override string ToString()
        {
            return ModelName + " " + CreationDate;
        }
    }
}
