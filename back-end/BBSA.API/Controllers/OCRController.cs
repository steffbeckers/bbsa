using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BBSA.API.Controllers
{
    [Route("api/ocr")]
    [ApiController]
    public class OCRController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public Task TestAsync()
        {
            return Task.CompletedTask;
        }
    }
}