using AutoMapper;
using CleaningManagement.BLL.Contracts;
using CleaningManagement.DomainModel.Entities;
using CleaningManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleaningManagement.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICleaningPlanService _cleaningPlanService;
        private readonly IMapper _mapper;
        public CustomerController(ICleaningPlanService cleaningPlanService, IMapper mapper)
        {
            _cleaningPlanService = cleaningPlanService;
            _mapper = mapper;
        }

        [HttpGet("{customerId}/cleaningplans")]
        public async Task<ActionResult<CleaningPlanResponseModel>> GetAllCleaningPlansForCustomerAsync(int customerId)
        {
            var cleaningPlans = await _cleaningPlanService.GetAllCleaningPlansForCustomerAsync(customerId);

            return Ok(cleaningPlans);
        }

        [HttpGet("{customerId}/cleaningplans/{id}")]
        public async Task<ActionResult<CleaningPlanResponseModel>> GetCleaningPlanForCustomerAsync(int customerId,
            Guid id)
        {
            var cleaningPlan = await _cleaningPlanService.GetCleaningPlanForCustomerByIdAsync(customerId, id);

            if(cleaningPlan == null)
            {
                return NotFound();
            }

            return _mapper.Map<CleaningPlanResponseModel>(cleaningPlan);
        }

        [HttpPost("{customerId}/cleaningplans")]
        public async Task<ActionResult<CleaningPlanResponseModel>> CreateCleaningPlanForCustomerAsync(int customerId,
            [FromBody]CleaningPlanCreationModel cleaningPlanModel)
        {
            var cleaningPlanForCreation = _mapper.Map<CleaningPlan>(cleaningPlanModel);
            cleaningPlanForCreation.CustomerId = customerId;

            var cleaningPlan = await _cleaningPlanService.CreateCleaningPlanAsync(
                _mapper.Map<CleaningPlan>(cleaningPlanForCreation));

            var cleaningPlanResponseModel = _mapper.Map<CleaningPlanResponseModel>(cleaningPlan);

            return Created($"api/customers{customerId}/cleaningplans{cleaningPlan.Id}", cleaningPlanResponseModel);
        }
    }
}
