using ApiaryDiary.Application.Users.DTO;
using ApiaryDiary.Application.Users.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Auth;
using Shared.Contexts;

namespace ApiaryDiary.Api.Controllers.Users
{
    [ApiController]
    [Route("Users/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly IContext _context;

        public AccountController(IIdentityService identityService, IContext context)
        {
            _identityService = identityService;
            _context = context;
        }
        [HttpGet("Location")]
        public ActionResult<string> Get()
            => OkOrNotFound("UsersController");

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AccountDto>> GetAsync()
         => OkOrNotFound(await _identityService.GetAsync(_context.Identity.Id));


        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUpAsync(SignUpDto dto)
        {
            await _identityService.SignUpAsync(dto);
            return NoContent();
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<JsonWebToken>> SignInAsync(SignInDto dto)
            => Ok(await _identityService.SignInAsync(dto));
    }
}
