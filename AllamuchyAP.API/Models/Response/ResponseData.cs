using System.Collections.Generic;

namespace AllamuchyAP.API.Helpers
{
    public partial class RequestHelper
    {
        public class ResponseData
        {
            public int Count { get; set; }
            public string Message { get; set; }
            public string SearchCriteria { get; set; }
            public List<Result> Results { get; set; }
        }

        public class ResponseDataLoDash
        {
            public int Count { get; set; }
            public string Message { get; set; }
            public string SearchCriteria { get; set; }
            public List<ResultLoDash> Results { get; set; }
        }
    }
}
