using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllamuchyAP.DataAccess.Models
{
    [Table("Year")]
    public class VehicleYear
    {
        public int Id { get; set; }
        public int Year { get; set; }
    }
}
