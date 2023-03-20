using API.Application.Query;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<FlightsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FlightsController(
            ILogger<FlightsController> logger,
            IMediator mediator,
            IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IActionResult> GetAvailableFlights(string destinationCode)
    {
        if (string.IsNullOrWhiteSpace(destinationCode) || destinationCode.Length != 3)
        {
            throw new FlightDomainException("The Airport code must be three characters.");
        }

        var airport = await _mediator.Send(new GetAvailableFlightsQuery
        {
            DestinationAirportCode = destinationCode
        });

        return Ok(_mapper.Map<ICollection<FlightViewModel>>(airport));
    }
}
