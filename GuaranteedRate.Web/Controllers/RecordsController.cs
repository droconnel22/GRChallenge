using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuaranteedRate.Domain.Services;
using GuaranteedRate.Domain.ViewModels;
using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Models.Persons.Strategies;

namespace GuaranteedRate.Web.Controllers
{
    [RoutePrefix("api/records")]
    public class RecordsController : ApiController
    {
        private readonly IPersonsService personsService;
      
        //Todo: Add DOC
        public RecordsController()
        {
            this.personsService = new PersonsService();
            this.personsService.Initalize(
                () => 
                PersonsRestBuilder
                .Initalize()
                .LoadMockData()
                .SetStrategyForPersons(new RestApiPersonsStrategy())
                .Build());      
        }

        [HttpPost]
       
        // POST api/records/
        public IHttpActionResult Post([FromBody] string model)
        {
            try
            {
                if (!ModelState.IsValid) return this.BadRequest("Model not valid.");
                return this.personsService
                    .AddRecord(model)
                    ? (IHttpActionResult) this.Ok()
                    : this.BadRequest();
            }
            catch (Exception exception)
            {
                return this.InternalServerError();
            }
        }

        [HttpGet]
        [Route("Gender")]
        // GET api/records/gender
        public IHttpActionResult Gender() => this.Ok(this.personsService.GetRecordsByGender());

        [HttpGet]
        // GET api/records/birthdate
        [Route("BirthDate")]
        public IHttpActionResult BirthDate() => this.Ok(this.personsService.GetRecordsByBirthDate());

        [HttpGet]
        [Route("Name")]
        // GET api/records/name
        public IHttpActionResult Name() => this.Ok(this.personsService.GetRecordsByName());
    }
}
