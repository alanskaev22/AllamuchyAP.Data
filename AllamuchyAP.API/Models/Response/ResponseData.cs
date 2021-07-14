namespace AllamuchyAP.API.Helpers
{
    public partial class RequestHelper
    {
        public class ResponseData
        {
            public int Count { get; set; }
            public string Message { get; set; }
            public string SearchCriteria { get; set; }
            public Result[] Results { get; set; }
        }
    }
}
