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
    public class RentalTransactionController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var rentalTransactionsBusiness = new RentalTransactionsBusiness())
            {
                // Get customers from business layer (Core App)
                List<RentalTransactions> rentalTransactions = rentalTransactionsBusiness.SelectAllRentalTransaction();

                // Prepare a content
                var content = new ResponseContent<RentalTransactions>(rentalTransactions);

                // Return content as a json and proper http response
                return new StandartResult<RentalTransactions>(content, Request);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            using (var rentalTransactionsBusiness = new RentalTransactionsBusiness())
            {
                RentalTransactions rentalTransaction = rentalTransactionsBusiness.SelectRentalTransactionleById(id);
                List<RentalTransactions> rentalTransactions= new List<RentalTransactions>();
                rentalTransactions.Add(rentalTransaction);

                var content = new ResponseContent<RentalTransactions>(rentalTransactions);

                return new StandartResult<RentalTransactions>(content, Request);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]RentalTransactions rentalTransactions)
        {
            var content = new ResponseContent<RentalTransactions>(null);
            if (rentalTransactions != null)
            {
                using (var rentalTransactionsBusiness = new RentalTransactionsBusiness())
                {
                    content.Result = rentalTransactionsBusiness.InsertRentalTransaction(rentalTransactions) ? "1" : "0";

                    return new StandartResult<RentalTransactions>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<RentalTransactions>(content, Request);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]RentalTransactions rentalTransactions)
        {
            var content = new ResponseContent<RentalTransactions>(null);

            if (rentalTransactions != null)
            {
                using (var rentalTransactionsBusiness = new RentalTransactionsBusiness())
                {
                    rentalTransactions.RentalID = id;
                    content.Result = rentalTransactionsBusiness.UpdateRentalTransaction(rentalTransactions) ? "1" : "0";

                    return new StandartResult<RentalTransactions>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<RentalTransactions>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<RentalTransactions>(null);

            using (var rentalTransactionsBusiness = new RentalTransactionsBusiness())
            {
                content.Result = rentalTransactionsBusiness.DeleteRentalTransactionById(id) ? "1" : "0";

                return new StandartResult<RentalTransactions>(content, Request);
            }
        }
    }
}