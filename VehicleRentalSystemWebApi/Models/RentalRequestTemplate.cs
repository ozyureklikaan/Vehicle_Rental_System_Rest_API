using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRentalSystemWebApi.Models
{
    public class RentalRequestTemplate
    {
        public int PersonID { get; set; }

        public int VehicleID { get; set; }
    }
}