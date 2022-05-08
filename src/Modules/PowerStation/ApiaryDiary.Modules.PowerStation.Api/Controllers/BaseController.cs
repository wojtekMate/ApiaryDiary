﻿
using Microsoft.AspNetCore.Mvc;

namespace ApiaryDiary.Modules.PowerStation.Api.Controllers
{
    [Route(PowerStationModule.BasePath + "/[controller]")]
    public class BaseController : Controller
    {
        protected ActionResult<T> OkOrNotFound<T>(T model)
        {
            if (model is not null)
            {
                return Ok(model);
            }

            return NotFound();
        }
    }
}
