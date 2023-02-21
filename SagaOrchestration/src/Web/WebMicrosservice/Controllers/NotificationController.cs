using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WebMicroservice.Controllers
{
    [Route("api/[Controller]/[Action]")]
    public class NotificationController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Notify()
        {
            return Ok();
        }
    }
}
