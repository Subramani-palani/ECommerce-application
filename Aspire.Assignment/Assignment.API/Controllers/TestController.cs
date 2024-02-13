using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class TestController : ControllerBase
    {
        [HttpGet("")]
        public string GetTestMessage(){
            return "Sample Testing Message";
        }
    }
}