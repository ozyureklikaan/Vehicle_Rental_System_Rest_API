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
    public class CompanyController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var companyBusiness = new CompaniesBusiness())
            {
                List<Companies> companies = companyBusiness.SelectAllCompanies();

                var content = new ResponseContent<Companies>(companies);

                return new StandartResult<Companies>(content, Request);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            using (var companiesBusiness = new CompaniesBusiness())
            {
                Companies company = companiesBusiness.SelectCompanyById(id);
                List<Companies> companies= new List<Companies>();
                companies.Add(company);

                var content = new ResponseContent<Companies>(companies);

                return new StandartResult<Companies>(content, Request);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Companies companies)
        {
            var content = new ResponseContent<Companies>(null);
            if (companies != null)
            {
                using (var companiesBusiness = new CompaniesBusiness())
                {
                    content.Result = companiesBusiness.InsertCompany(companies) ? "1" : "0";

                    return new StandartResult<Companies>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Companies>(content, Request);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Companies companies)
        {
            var content = new ResponseContent<Companies>(null);

            if (companies != null)
            {
                using (var companiesBusiness = new CompaniesBusiness())
                {
                    companies.CompanyID = id;
                    content.Result = companiesBusiness.UpdateCompany(companies) ? "1" : "0";

                    return new StandartResult<Companies>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Companies>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Companies>(null);

            using (var companiesBusiness = new CompaniesBusiness())
            {
                content.Result = companiesBusiness.DeleteCompanyById(id) ? "1" : "0";

                return new StandartResult<Companies>(content, Request);
            }
        }
    }
}