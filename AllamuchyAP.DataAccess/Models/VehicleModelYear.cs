using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllamuchyAP.DataAccess.Models
{
    [Table("Model_Year")]
    public class VehicleModelYear
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int YearId { get; set; }

    }
}
