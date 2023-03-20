using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using System.Linq;

namespace API.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightViewModel>()
                .ForMember(dest => dest.ArrivalAirportCode,
                           opt => opt.MapFrom(src => src.DestinationAirport.Code))
                .ForMember(dest => dest.DepartureAirportCode,
                           opt => opt.MapFrom(src => src.OriginAirport.Code))
                .ForMember(dest => dest.PriceFrom,
                           opt => opt.MapFrom(src => src.Rates.Select(t => new { Price = t.Price.Value }).OrderBy(t => t.Price).FirstOrDefault().Price))
                .ForMember(dest => dest.FlightRateId,
                           opt => opt.MapFrom(src => src.Rates.Select(t => new { Price = t.Price.Value, t.Id }).OrderBy(t => t.Price).FirstOrDefault().Id));

        }
    }
}