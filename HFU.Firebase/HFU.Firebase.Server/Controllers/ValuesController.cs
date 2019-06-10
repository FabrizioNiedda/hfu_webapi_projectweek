using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HFU.Firebase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(Firebase firebase)
        {
            _firebase = firebase;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            // TODO: Example on how to use the service. Inject it with the IOC of asp.net core.
            var result = _firebase.SendMessage(
                "fyL1iD2ptDA:APA91bHkg6CdFaa2o1Xvc127XB1p21m9wNR9g42TPBfp0bY8AUlz0tD4AyOQ8mYWJB7xFlh9JqbAT0Y8pSIBA8rIJkDQPdlHukHYCbfUkZqHRUt0LAxFbw8bnYXNbAWdjHf0FmTAHQ6K",
                new Dictionary<string, string>()).Result;

            return new string[] {"value1", "value2", result};
        }

        private readonly Firebase _firebase;
    }
}