using checkout_web_local_api.Printer;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace checkout_web_local_api.Controller
{
    [RoutePrefix("api/Sales")]
    public class SalesController : ApiController
    {
        public SalesController()
        {

        }
        [HttpGet()]
        [Route("getxml")]
        public IEnumerable<string> GetXML()
        {
            return new string[] { "Hello", "XmlResponse" };
        }
        // GET api/demo 
        [HttpGet()]
        [Route("teste")]
        public IHttpActionResult Get()
        {
            return Ok(new { key = "Hello", value = "Teste!" });
        }
        // GET api/demo 
        [HttpGet()]
        [Route("")]
        public IHttpActionResult defaultget()
        {
            Generate.createPDF();
            //return new string[] { "Hello", "World" };
            return Json(new { key = "Hello", value = "Default!" });
        }

        // GET api/demo/{dado1}/{dado2}
        [HttpGet()]
        [Route("{dado1}/{dado2}")]
        public IHttpActionResult values(string dado1, int dado2)
        {
            return Json(new { key = dado1, value = dado2 });
        }

        // POST api/demo 
        public void Post([FromBody] string value)
        {
        }

        // PUT api/demo/5 
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/demo/5 
        public void Delete(int id)
        {
        }
    }
}
