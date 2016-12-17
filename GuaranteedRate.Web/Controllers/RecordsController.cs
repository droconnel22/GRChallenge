using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuaranteedRate.Domain.Services;
using GuaranteedRate.Domain.ViewModels;

namespace GuaranteedRate.Web.Controllers
{
    [RoutePrefix("records")]
    public class RecordsController : ApiController
    {
        private IPersonsService personsService;
      
        public RecordsController()
        {
            
        }

        [HttpPost]
        [Route("POST")]
        // POST api/records/
        public IHttpActionResult Post([FromBody] string model)
        {
            try
            {
                if (!ModelState.IsValid) return this.BadRequest("Model not valid.");

                return this.personsService
                    .BuildPerson(model)
                    .AddRecord()
                    ? (IHttpActionResult) this.Ok()
                    : this.BadRequest();
            }
            catch (Exception exception)
            {
                return this.InternalServerError();
            }
        }

        [HttpGet]
        // GET api/records/gender
        public IHttpActionResult Gender() => this.Ok(this.personsService.GetRecordsByGender());

        [HttpGet]
        // GET api/records/birthdate
       
        public IHttpActionResult BirthDate() => this.Ok(this.personsService.GetRecordsByBirthDate());

        [HttpGet]
        // GET api/records/name
        public IHttpActionResult Name() => this.Ok(this.personsService.GetRecordsByName());
    }
}
