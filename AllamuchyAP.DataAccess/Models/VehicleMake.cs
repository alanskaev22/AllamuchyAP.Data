﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllamuchyAP.DataAccess.Models
{
    [Table("Make")]
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
