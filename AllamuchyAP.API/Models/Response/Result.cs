namespace AllamuchyAP.API.Helpers
{
    public partial class RequestHelper
    {
        public class Result
        {
            public int MakeId { get; set; }
            public string MakeName { get; set; }
            public int Model_ID { get; set; }
            public string Model_Name { get; set; }
            public int VehicleTypeId { get; set; }
            public string VehicleTypeName { get; set; }
        }

        public class ResultLoDash
        {
            public int Make_ID { get; set; }
            public string Make_Name { get; set; }
            public int Model_ID { get; set; }
            public string Model_Name { get; set; }
            public int VehicleTypeId { get; set; }
            public string VehicleTypeName { get; set; }
        }
    }
}
