using AllamuchyAP.API.Helpers;
using AllamuchyAP.DataAccess.Models;
using AllamuchyAP.DataAccess.Repository;
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
        private readonly IVehicleRepository _repository;

        public Program()
        {

        }

        public Program(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public static async Task Main(string[] args)
        {

            var prog = new Program();

            Console.WriteLine("");
            await prog.Run();
            
        }

        public async Task Run()
        {
            var years = await _repository.GetAllYears();
            var makes = (await RequestHelper.GetMakesForPassengerCar()).Results;

            List<VehicleModelYear> dbModelYears = new List<VehicleModelYear>();

            foreach (var year in years)
            {
                foreach (var make in makes)
                {
                    var modelsForYear = RequestHelper.GetModelsForYearByMakeNamePassengerCar(year.Year, make.MakeName);
                    dbModelYears = modelsForYear.Result.Results
                        .Select(m => new VehicleModelYear
                        {
                            ModelId = m.Model_ID,
                            YearId = year.Id
                        }).ToList();

                    await _repository.AddModelYears(dbModelYears);
                }
            }
        }
    }

}