using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.Site.User.Application.Dto;
using Web.Site.User.Application.Service;

namespace Web.Site.User.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class UserController: Controller
    {

        IAuthenticationAplicationService _authenticationAplicationService;
        public UserController(IAuthenticationAplicationService authenticationAplicationService)
        {
            _authenticationAplicationService = authenticationAplicationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult SignUp([FromBody]UserCreateDTO model)
        {
            _authenticationAplicationService.SignUp(model);
            return Ok("SignUp was  good");
        }
    }
}
