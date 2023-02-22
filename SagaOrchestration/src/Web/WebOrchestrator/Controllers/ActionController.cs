using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebOrchestrator.Controllers
{
    /// <summary>
    /// Actions allowed
    /// </summary>
    [Route("api/[Controller]/[Action]")]
    public class ActionController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ActionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> PublishCube()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("Legacy");
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("/api/Cube/Publish");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                httpClient = _httpClientFactory.CreateClient("Microservice");
                httpResponseMessage = await httpClient.GetAsync("/api/Notification/Notify");
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    httpClient = _httpClientFactory.CreateClient("Legacy");
                    httpResponseMessage = await httpClient.GetAsync("/api/Cube/UndoPublish");
                }
            }
            return Ok();
        }
    }
}
