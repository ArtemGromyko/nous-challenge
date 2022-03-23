using AutoMapper;
using CleaningManagement.BLL.Contracts;
using CleaningManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleaningManagement.Api.Controllers
{
    [ApiController]
    [Route("api/cleaningplans")]
    public class CleaningPlansController : ControllerBase
    {
        private readonly ICleaningPlanService _cleaningPlanService;
        private readonly IMapper _mapper;

        public CleaningPlansController(ICleaningPlanService cleaningPlanService, IMapper mapper)
        {
            _cleaningPlanService = cleaningPlanService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCleaningPlanById(Guid id)
        {
            var cleaningPlan = await _cleaningPlanService.GetCleaningPlanByIdAsync(id);

            if(cleaningPlan == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CleaningPlanResponseModel>(cleaningPlan));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCleaningPlanById(Guid id)
        {
            var cleaningPlan = await _cleaningPlanService.GetCleaningPlanByIdAsync(id);

            if (cleaningPlan == null)
            {
                return NotFound();
            }

            await _cleaningPlanService.DeleteCleaningPlanAsync(cleaningPlan);
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCleaningPlan(Guid id, 
        [FromBody] CleaningPlanUpdateModel cleaningPlanUpdateModel)
        {
            var cleaningPlan = await _cleaningPlanService.GetCleaningPlanByIdAsync(id);

            if (cleaningPlan == null)
            {
                return NotFound();
            }
            
            _mapper.Map(cleaningPlanUpdateModel, cleaningPlan);
            await _cleaningPlanService.UpdateCleaningPlanAsync(cleaningPlan);

            return NoContent();
        }
    }
}