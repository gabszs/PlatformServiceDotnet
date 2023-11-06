using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController() { }

        [HttpPost]
        public ActionResult TesteInboundCOnnection()
        {
            Console.WriteLine("Ok ----->>>> InboundTest on Post endpoint at # Command Service");

            return Ok("Inbound Test of platforms controller was OK");
        }
    }
}