using AllamuchyAP.DataAccess.DataAccess;
using AllamuchyAP.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllamuchyAP.DataAccess.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehiclesContext _dbContext;

        public VehicleRepository(VehiclesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMakes(List<VehicleMake> makes)
        {
            await _dbContext.Makes.AddRangeAsync(makes);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<VehicleModel>> AddModels(List<VehicleModel> dbModels)
        {
            await _dbContext.Models.AddRangeAsync(dbModels);
            await _dbContext.SaveChangesAsync();

            return dbModels;
        }

        public async Task<List<VehicleModelYear>> AddModelYears(List<VehicleModelYear> modelYears)
        {
            await _dbContext.ModelYears.AddRangeAsync(modelYears);
            await _dbContext.SaveChangesAsync();

            return modelYears;
        }

        public async Task<List<VehicleMake>> GetAllMakes()
        {
            return await _dbContext.Makes.ToListAsync();
        }

        public async Task<List<VehicleYear>> GetAllYears()
        {
            return await _dbContext.Years.ToListAsync();
        }


    }
}
