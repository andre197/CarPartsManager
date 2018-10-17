namespace CarPartsManager.Logic.Helpers
{
    using System;

    public class CarPartsViewHelper
    {
        public int PartId { get; set; }
        public int ModelId { get; set; }
        public int MakerId { get; set; }
        public string MakerName { get; set; }
        public string Model { get; set; }
        public DateTime CreationDate { get; set; }
        public string PartName { get; set; }
        public int Quantity { get; set; }
        public string PartUniqueNumber { get; set; }
    }
}
