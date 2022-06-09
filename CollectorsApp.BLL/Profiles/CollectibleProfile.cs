using AutoMapper;
using CollectorsApp.BLL.DataTransferObjects;
using CollectorsApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.Profiles
{
    public class CollectibleProfile : Profile
    {
        public CollectibleProfile()
        {
            CreateMap<CollectibleDto, Collectible>()
                .ForMember(dest => dest.Id, m => m.Ignore())
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
