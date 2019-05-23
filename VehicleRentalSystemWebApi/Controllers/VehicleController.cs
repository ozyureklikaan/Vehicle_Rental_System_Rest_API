using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VehicleRentalSystemWebApi.Models;
using VehicleRentalSystemWebApi.Results;
using VehicleRentalSystem.BusinessLogic.Concretes;
using VehicleRentalSystem.Commons.Concretes.Helpers;
using VehicleRentalSystem.Models.Concretes;

namespace VehicleRentalSystemWebApi.Controllers
{
    public class VehicleController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var vehiclesBusiness = new VehiclesBusiness())
            {
                List<Vehicles> vehicles = vehiclesBusiness.SelectAllVehicles();

                var content = new ResponseContent<Vehicles>(vehicles);

                return new StandartResult<Vehicles>(content, Request);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            using (var vehiclesBusiness = new VehiclesBusiness())
            {
                Vehicles vehicle = vehiclesBusiness.SelectVehicleById(id);
                List<Vehicles> vehicles = new List<Vehicles>();
                vehicles.Add(vehicle);

                var content = new ResponseContent<Vehicles>(vehicles);

                return new StandartResult<Vehicles>(content, Request);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Vehicles vehicles)
        {
            var content = new ResponseContent<Vehicles>(null);
            if (vehicles != null)
            {
                using (var vehiclesBusiness = new VehiclesBusiness())
                {
                    content.Result = vehiclesBusiness.InsertVehicle(vehicles) ? "1" : "0";

                    return new StandartResult<Vehicles>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Vehicles>(content, Request);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Vehicles vehicles)
        {
            var content = new ResponseContent<Vehicles>(null);

            if (vehicles != null)
            {
                using (var vehiclesBusiness = new VehiclesBusiness())
                {
                    vehicles.VehicleID = id;
                    content.Result = vehiclesBusiness.UpdateVehicle(vehicles) ? "1" : "0";

                    return new StandartResult<Vehicles>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Vehicles>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Vehicles>(null);

            using (var vehiclesBusiness = new VehiclesBusiness())
            {
                content.Result = vehiclesBusiness.DeleteVehicleById(id) ? "1" : "0";

                return new StandartResult<Vehicles>(content, Request);
            }
        }
    }
}
