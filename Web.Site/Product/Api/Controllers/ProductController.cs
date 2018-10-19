namespace Web.Site.Product.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Application.Dto;
    using Application.Service;
    using System.Collections.Generic;
    using System.Net;

    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly IAmqpApplicationService _amqpApplicationService;
        public ProductController(IProductApplicationService productApplicationService,
            IAmqpApplicationService amqpApplicationService)
        {
            _productApplicationService = productApplicationService;
            _amqpApplicationService = amqpApplicationService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductOutputDto), (int)HttpStatusCode.OK)]
        public IActionResult Get(int id)
        {
            return Ok(_productApplicationService.Get(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductOutputDto>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            return  Ok(_productApplicationService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Create([FromBody] ProductCreateDto model)
        {
            long productId = _productApplicationService.Create(model);
            _amqpApplicationService.PublishMessage(productId);
            return Ok("Product Created!");
        }

        [HttpGet("expensives")]
        [ProducesResponseType(typeof(List<ProductOutputDto>), (int)HttpStatusCode.OK)]
        public IActionResult GetExpensives()
        {
            return Ok(_productApplicationService.GetExpensives());
        }
    }
}