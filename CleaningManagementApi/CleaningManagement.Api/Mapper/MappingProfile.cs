using AutoMapper;
using CleaningManagement.DomainModel.Entities;
using CleaningManagement.Models;

namespace CleaningManagement.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CleaningPlanCreationModel, CleaningPlan>();
            CreateMap<CleaningPlan, CleaningPlanResponseModel>();
            CreateMap<CleaningPlanUpdateModel, CleaningPlan>();
        }
    }
}
