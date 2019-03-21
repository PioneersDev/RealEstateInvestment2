using AutoMapper;
using RealEstateInvestment.Areas.RealEstate.BL;
using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Project, ProjectDTO>();
            Mapper.CreateMap<ProjectOwner, ProjectDTO>();

            Mapper.CreateMap<ProjectDTO, Project>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<ProjectDTO, ProjectOwner>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<ContractRequests, ContractApproveModel>();
        }
    }
}