namespace Web.Site.User.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Net;
    using Web.Site.User.Application.Dto;
    using Web.Site.User.Application.Service;

    [Produces("application/json")]
    [Route("api/users")]
    public class UserController: Controller
    {

        IUserAplicationService _userAplicationService;
        public UserController(IUserAplicationService userAplicationService)
        {
            _userAplicationService = userAplicationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserOutputDto>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            return Ok(_userAplicationService.GetAll());
        }

        [HttpPost("auth")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult SignUp([FromBody]UserCreateDto model)
        {
            _userAplicationService.SignUp(model);
            return Ok("SignUp was good");
        }
    }
}
