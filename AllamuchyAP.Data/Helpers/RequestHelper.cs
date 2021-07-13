using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AllamuchyAP.Data.Helpers
{
    public partial class RequestHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<ResponseData> GetModelsForYearByMakeId(int year, int makeId)
        {
            string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json";

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = client.GetStreamAsync(url);

            var models = await JsonSerializer.DeserializeAsync<ResponseData>(await streamTask);

            return models;
        }
    }
}
