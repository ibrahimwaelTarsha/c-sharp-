using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncAwaitApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AsyncController : ControllerBase
    {


        [HttpGet]



        public async Task<IActionResult>get()
        {
            await Task.Delay(1000);

            return Ok("helow c#");
        }



    }
}
