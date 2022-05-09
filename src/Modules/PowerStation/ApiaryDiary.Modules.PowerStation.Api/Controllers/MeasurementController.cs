using ApiaryDiary.Shared.Abstractions.Auth;
using ApiaryDiary.Shared.Abstractions.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiaryDiary.Modules.PowerStation.Api.Controllers
{
    public class MeasurementController : BaseController
    {
        private readonly IContext _context;
        public MeasurementController( IContext context)
        {
            _context = context;
        }
        [HttpGet("Location")]
        public ActionResult<string> Get()
            => OkOrNotFound("Power-Station-Measurement-Controller");
        
    }
}
