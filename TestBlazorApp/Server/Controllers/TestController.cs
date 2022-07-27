using Microsoft.AspNetCore.Mvc;
using TestBlazorApp.Server.Service;
using TestBlazorApp.Shared;

namespace TestBlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        TestService testService;

        public TestController(TestService testService)
        {
            this.testService = testService;
        }

        [HttpGet]
        public async Task<string> TestCall()
        {
            testService.TestMethod();
            return "hello";
        }

        [HttpPost]
        public async Task<IActionResult> PostCall(TestItem test)
        {
            return BadRequest("Error");
        }
    }
}
