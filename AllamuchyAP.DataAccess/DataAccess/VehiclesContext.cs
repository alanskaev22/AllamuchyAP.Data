using AllamuchyAP.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllamuchyAP.DataAccess.DataAccess
{
    public class VehiclesContext : DbContext
    {
        public VehiclesContext(DbContextOptions options) : base(options) { }
        
        public DbSet<VehicleMake> Makes{ get; set; }
        public DbSet<VehicleModel> Models { get; set; }
        public DbSet<VehicleModelYear> ModelYears { get; set; }
        public DbSet<VehicleYear> Years { get; set; }
    }
}
