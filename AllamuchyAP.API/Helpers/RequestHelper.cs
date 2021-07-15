using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AllamuchyAP.API.Helpers
{
    public partial class RequestHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public RequestHelper()
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static async Task<ResponseData> GetModelsForYearByMakeId(int year, int makeId)
        {
            string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json";

            var streamTask = client.GetStreamAsync(url);

            var models = await JsonSerializer.DeserializeAsync<ResponseData>(await streamTask);


            return models;
        }

        public static async Task<ResponseDataLoDash> GetModelsForYearByMakeNamePassengerCar(int year, string makeName)
        {
            string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeYear/make/{makeName}/modelyear/{year}/vehicletype/Passenger Car?format=json";

            //var streamTask = client.GetStreamAsync(url);

            //var models = await JsonSerializer.DeserializeAsync<ResponseDataLoDash>(await streamTask);

            //return models;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStreamAsync();

                        return await JsonSerializer.DeserializeAsync<ResponseDataLoDash>(apiResponse);

                    }
                    return null;
                }
            }
        }

        public static async Task<ResponseData> GetModelsForYearByMakeNameMultiPurposeCar(int year, string makeName)
        {
            string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeYear/make/{makeName}/modelyear/{year}/vehicletype/Multipurpose Passenger Vehicle (MPV)?format=json";

            var streamTask = client.GetStreamAsync(url);

            var models = await JsonSerializer.DeserializeAsync<ResponseData>(await streamTask);

            return models;
        }

        public static async Task<ResponseData> GetMakesForPassengerCar()
        {
            string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetMakesForVehicleType/car?format=json";


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStreamAsync();

                        return await JsonSerializer.DeserializeAsync<ResponseData>(apiResponse);

                    }
                    return null;
                }
            }


            //HttpClient httpClient = new HttpClient();
            //var response = await httpClient.GetAsync(url);
            //Stream stream = null;
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    stream = await response.Content.ReadAsStreamAsync();
            //}


            //var streamTask = client.GetStreamAsync(url);

            //var models = await JsonSerializer.DeserializeAsync<ResponseData>(stream);

            //return models;

        }

        public static async Task<ResponseData> GetMakesForMultuPurposeCar()
        {
            string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetMakesForVehicleType/Multipurpose Passenger Vehicle (MPV)?format=json";

            var streamTask = client.GetStreamAsync(url);

            var models = await JsonSerializer.DeserializeAsync<ResponseData>(await streamTask);

            return models;

        }
    }
}
