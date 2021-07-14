namespace AllamuchyAP.API
{
    public partial class Program
    {
        public class CarModel
        {
            public int MakeId { get; set; }
            public string MakeName { get; set; }
            public int ModelId { get; set; }
            public string ModelName { get; set; }
            public int ModelYear { get; set; }
            public int? VehicleTypeId { get; set; }
            public string VehicleTypeName { get; set; }

        }
    }

}