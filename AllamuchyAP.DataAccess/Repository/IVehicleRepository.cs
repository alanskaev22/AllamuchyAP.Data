using AllamuchyAP.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllamuchyAP.DataAccess.Repository
{
    public interface IVehicleRepository
    {
        Task<List<VehicleYear>> GetAllYears();
        Task<List<VehicleMake>> GetAllMakes();
        Task<List<VehicleModelYear>> AddModelYears(List<VehicleModelYear> modelYears);
        Task AddMakes(List<VehicleMake> makes);
        Task<List<VehicleModel>> AddModels(List<VehicleModel> dbModels);
    }
}
