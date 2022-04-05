using Microsoft.AspNetCore.Mvc;
using TestBlazorApp.Server.Service;

namespace TestBlazorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JsonController : Controller
    {
        TestService testService;

        public JsonController(TestService testService)
        {
            this.testService = testService;
        }

        [HttpGet]
        public async Task<string> TestCall()
        {
            testService.TestMethod();
            return "hello";
        }
    }
}
