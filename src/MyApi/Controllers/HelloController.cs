using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi {

    [Route("api/[controller]/[action]")]
    public class HelloController : ControllerBase {

        private readonly ILogger<HelloController> logger;
        public HelloController(ILogger<HelloController> logger) {
            this.logger = logger;
        }

        [HttpGet()]
        public ActionResult<dynamic> Hello() {
            logger.LogInformation("Call HI");
            return new {
                Hi = "xxxx"
            };
        }
    }
}