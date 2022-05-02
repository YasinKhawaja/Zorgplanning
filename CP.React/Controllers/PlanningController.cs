using AutoWrapper.Wrappers;
using CP.BLL.DTOs;
using CP.BLL.Services.Planning;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CP.React.Controllers
{
    [ApiController]
    [Route("api/planning")]
    public class PlanningController : ControllerBase
    {
        private readonly ILogger<PlanningController> _logger;
        private readonly PlanningService _planningService; // TODO: interface

        public PlanningController(ILogger<PlanningController> logger, PlanningService planningService)
        {
            _logger = logger;
            _planningService = planningService;
        }

        #region GET: api/<PlanningController>
        [HttpGet]
        public async Task<ApiResponse> GetAsync([FromQuery] int teamId, int year, int month)
        {
            PlanningGetDto planningGetDto;
            try
            {
                planningGetDto = await _planningService.GetMonthlyPlanningAsync(teamId, year, month);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
            return new ApiResponse(planningGetDto);
        }
        #endregion

        #region POST: api/<PlanningController>
        [HttpPost]
        public async Task<ApiResponse> PostAsync([FromBody] PlanningPostDto planningCreateDTO)
        {
            try
            {
                object v = await _planningService.GenerateMonthlyPlanning(planningCreateDTO);
                return new ApiResponse(v);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc.Message);
            }
        }
        #endregion
    }
}
