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
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamDto, Team>()
                .ForMember(dest => dest.Id, m => m.Ignore())
                .ForMember(dest => dest.Teamname, m => m.MapFrom(src => src.Teamname))
                .ReverseMap();
        }
    }
}
