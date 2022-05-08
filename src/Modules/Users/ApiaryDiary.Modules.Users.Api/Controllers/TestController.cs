using Microsoft.AspNetCore.Mvc;

namespace ApiaryDiary.Modules.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        { 
			return "working CI/CD...";      
        }
    }
}
