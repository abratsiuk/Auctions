using AutoMapper;
using api.Models;
using api.Models.Dtos;

namespace api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuctionDto, Auction>().ReverseMap();
        }
    }
}
