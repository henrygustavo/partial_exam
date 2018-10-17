namespace Web.Site.Template.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Application.Dto;
    using Application.Service;
    using System.Collections.Generic;
    using System.Net;

    [Produces("application/json")]
    [Route("api/templates")]
    public class TemplateController : Controller
    {
        private readonly ITemplateApplicationService _templateApplicationService;

        public TemplateController(ITemplateApplicationService templateApplicationService)
        {
            _templateApplicationService = templateApplicationService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TemplateOutputDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int id)
        {
            return Ok(_templateApplicationService.Get(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TemplateOutputDto>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            return Ok(_templateApplicationService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Create([FromBody] TemplateCreateDto model)
        {
            _templateApplicationService.Create(model);
            return Ok("Template Created!");
        }
    }
}