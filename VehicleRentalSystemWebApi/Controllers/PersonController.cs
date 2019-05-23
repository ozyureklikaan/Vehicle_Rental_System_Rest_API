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
    public class PersonController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var personsBusiness = new PersonsBusiness())
            {
                // Get customers from business layer (Core App)
                List<Persons> persons = personsBusiness.SelectAllPersons();

                // Prepare a content
                var content = new ResponseContent<Persons>(persons);

                // Return content as a json and proper http response
                return new StandartResult<Persons>(content, Request);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            using (var personsBusiness = new PersonsBusiness())
            {
                Persons person = personsBusiness.SelectPersonById(id);
                List<Persons> persons = new List<Persons>();
                persons.Add(person);

                var content = new ResponseContent<Persons>(persons);

                return new StandartResult<Persons>(content, Request);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Persons persons)
        {
            var content = new ResponseContent<Persons>(null);
            if (persons != null)
            {
                using (var personsBusiness = new PersonsBusiness())
                {
                    content.Result = personsBusiness.InsertPerson(persons) ? "1" : "0";

                    return new StandartResult<Persons>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Persons>(content, Request);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Persons persons)
        {
            var content = new ResponseContent<Persons>(null);

            if (persons != null)
            {
                using (var personsBusiness = new PersonsBusiness())
                {
                    persons.PersonID = id;
                    content.Result = personsBusiness.UpdatePerson(persons) ? "1" : "0";

                    return new StandartResult<Persons>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Persons>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Persons>(null);

            using (var personsBusiness = new PersonsBusiness())
            {
                content.Result = personsBusiness.DeletePersonById(id) ? "1" : "0";

                return new StandartResult<Persons>(content, Request);
            }
        }
    }
}