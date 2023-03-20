using System.Threading.Tasks;
using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(
            ILogger<AirportsController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return Ok(_mapper.Map<OrderViewModel>(order));
        }

        [HttpPut]
        [Route("Confirm")]
        public async Task<IActionResult> ConfirmOrder([FromBody] ConfirmOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return Ok(_mapper.Map<OrderViewModel>(order));
        }
    }
}