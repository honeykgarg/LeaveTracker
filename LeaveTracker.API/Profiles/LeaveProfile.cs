using AutoMapper;
using LeaveTracker.API.Models;
using LeaveTracker.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveTracker.API.Profiles
{
    public class LeaveProfile : Profile
    {
        public LeaveProfile()
        {
            CreateMap<LeaveDto, Leave>();
            CreateMap<Leave, LeaveDto>();
                

        }
    }
}
