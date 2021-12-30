﻿using Microsoft.AspNetCore.Mvc;

namespace ApiaryDiary.Api.Controllers.Users
{
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