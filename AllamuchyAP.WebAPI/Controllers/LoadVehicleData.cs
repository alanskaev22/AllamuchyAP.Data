using AllamuchyAP.API.Helpers;
using AllamuchyAP.DataAccess.Models;
using AllamuchyAP.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllamuchyAP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoadVehicleData : ControllerBase
    {

        private readonly ILogger<LoadVehicleData> _logger;
        private readonly IVehicleRepository _repository;
        public LoadVehicleData(ILogger<LoadVehicleData> logger, IVehicleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task GetAsync()
        {
            var years = (await _repository.GetAllYears()).OrderByDescending(y => y.Id);
            var makes = await _repository.GetAllMakes();

            // Only call this when models don't exist in db.
            // await LoadModelsInDb();

            List<VehicleModel> allModelsForDb = new List<VehicleModel>();
            var modelsInDb = new List<VehicleModel>();

            foreach (var year in years)
            {
                List<Task<RequestHelper.ResponseDataLoDash>> listOfTasks = new List<Task<RequestHelper.ResponseDataLoDash>>();

                foreach (var make in makes)
                {
                    listOfTasks.Add(RequestHelper.GetModelsForYearByMakeNamePassengerCar(year.Year, make.Name));
                }

                await Task.WhenAll(listOfTasks);

                foreach (var task in listOfTasks.Where(t => t.Result != null).Select(t => t.Result))
                {
                    allModelsForDb.AddRange(task.Results
                        .Select(m => new VehicleModel
                        {
                            MakeId = makes.Where(x => x.Name == m.Make_Name).FirstOrDefault().Id,
                            Name = m.Model_Name

                        }));
                }

                if (modelsInDb.Count > 0)
                    foreach (var model in modelsInDb)
                    {
                        allModelsForDb.RemoveAll(m => m.Name == model.Name);
                    }


                var filteredModels = allModelsForDb
                .GroupBy(m => m.Name)
                .Select(m => m.First())
                .Select(m => m).ToList()
                .ConvertAll(m => new VehicleModel { MakeId = m.MakeId, Name = m.Name });

                var addModelsResponse = await _repository.AddModels(filteredModels);
                modelsInDb.AddRange(addModelsResponse);

                var modelYearsForDb = new List<VehicleModelYear>();

                foreach (var modelInDb in modelsInDb)
                {
                    modelYearsForDb.Add(
                        new VehicleModelYear
                        {
                            ModelId = modelInDb.Id,
                            YearId = year.Id
                        }
                    );
                };

                modelYearsForDb
                    .GroupBy(my => new { my.ModelId, my.YearId })
                    .Select(my => my.First());

                var modelYearResult = await _repository.AddModelYears(modelYearsForDb);

            }
        }

        private async Task LoadModelsInDb()
        {
            var apiMakes = await RequestHelper.GetMakesForPassengerCar();

            List<VehicleMake> dbMakes = new List<VehicleMake>();

            dbMakes.AddRange(apiMakes.Results.Select(m => new VehicleMake { Name = m.MakeName }));

            await _repository.AddMakes(dbMakes);
        }
    }
}
