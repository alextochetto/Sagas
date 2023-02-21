using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WebLegacy.Controllers
{
    [Route("api/[Controller]/[Action]")]
    public class CubeController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Publish()
        {
            return Ok();
        }
    }
}
