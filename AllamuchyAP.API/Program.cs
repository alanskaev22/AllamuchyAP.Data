using AllamuchyAP.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AllamuchyAP.API.Helpers.RequestHelper;

namespace AllamuchyAP.API
{
    public partial class Program
    {
        public static async Task Main(string[] args)
        {

            List<CarModel> allModelsForYearRange = new List<CarModel>();

            List<int> validAutoYears = Enumerable.Range(1996, 26).ToList();  // all years from 1996 to 2021

            validAutoYears.ForEach(year => 
                {
                    //var response = GetModelsForYearByMakeId(year, 449).Result;
                    var response = GetModelsForYearByMakeNamePassengerCar(year, "Bentley").Result;

                    allModelsForYearRange.AddRange((from result in response.Results
                                        select new CarModel()
                                        {
                                            MakeId = result.Make_ID,
                                            MakeName = result.Make_Name,
                                            ModelId = result.Model_ID,
                                            ModelName = result.Model_Name,
                                            ModelYear = year,
                                            VehicleTypeId = result.VehicleTypeId,
                                            VehicleTypeName = result.VehicleTypeName
                                        }).ToList());
                }
            );

            Console.WriteLine(allModelsForYearRange.Count);
        }
    }

}