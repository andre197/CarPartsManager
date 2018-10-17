namespace CarPartsManager.Logic.Helpers
{
    using System.Collections.Generic;

    public class CarMakerHelper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CarModelHelper> Models { get; set; } = new List<CarModelHelper>();
        public override string ToString()
        {
            return Name;
        }
    }
}
