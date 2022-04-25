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
        private readonly PlanningService _planningService;

        public PlanningController(ILogger<PlanningController> logger, PlanningService planningService)
        {
            _logger = logger;
            _planningService = planningService;
        }

        #region GET: api/<PlanningController>
        [HttpGet]
        public async Task<ApiResponse> GetAsync([FromQuery] int teamID, int year, int month)
        {
            try
            {
                var planning = await _planningService.GetMonthlyPlanningAsync(teamID, year, month);
                return new ApiResponse(planning);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        [HttpGet]
        [Route("export/excel")]
        public FileContentResult DownloadToExcelAsync(int teamId, int year, int month)
        {
            string fileName = $"{year}{FormatMonth(month)}-Planning-{teamId}.xlsx";
            var workbook = _planningService.BuildExcelFile(teamId, year, month);
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return File(stream.ToArray(), "application/octet-stream", fileName);
        }

        #region POST: api/<PlanningController>
        [HttpPost]
        public async Task<ApiResponse> PostAsync([FromBody] PlanningCreateDTO planningCreateDTO)
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

        private static string FormatMonth(int month)
        {
            return month < 10 ? $"0{month}" : month.ToString();
        }
    }
}
