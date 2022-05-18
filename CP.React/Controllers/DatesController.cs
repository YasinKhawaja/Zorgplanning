using AutoWrapper.Wrappers;
using CP.BLL.DTOs;
using CP.BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CP.React.Controllers
{
    [ApiController]
    [Route("api/dates")]
    public class DatesController : ControllerBase
    {
        private readonly ILogger<DatesController> _logger;
        private readonly ICalendarDateService _calendarDateService;

        public DatesController(ILogger<DatesController> logger, ICalendarDateService dateService)
        {
            _logger = logger;
            _calendarDateService = dateService;
        }

        #region GET: api/<CalendarDatesController>/holidays
        [HttpGet]
        [Route("holidays")]
        public async Task<ApiResponse> GetAllHolidaysAsync()
        {
            try
            {
                List<HolidayDTO> holidays = await _calendarDateService.GetAllHolidaysAsync();
                return new ApiResponse(holidays);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region GET api/<CalendarDatesController>/5
        [HttpGet("{id}")]
        public async Task<ApiResponse> GetAsync(int id)
        {
            try
            {
                var date = await _calendarDateService.GetAsync(id);
                return new ApiResponse(date);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region POST api/<CalendarDatesController>
        [HttpPost]
        [Route("holidays")]
        public async Task<ApiResponse> PostAsync([FromBody] HolidayDTO holidayDTO)
        {
            try
            {
                await _calendarDateService.AddHolidayAsync(holidayDTO);
                return new ApiResponse();
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region PUT api/<CalendarDatesController>/5
        [HttpPut("{id}")]
        public async Task<ApiResponse> PutAsync(int id, [FromBody] CalendarDateDTO dateDTO)
        {
            if (!id.Equals(1))
            {
                return new ApiResponse(400, "IDS DO NOT MATCH");
            }
            try
            {
                await _calendarDateService.UpdateAsync(id, dateDTO);
                return new ApiResponse();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region DELETE api/<CalendarDatesController>/5
        [HttpDelete]
        [Route("holidays")]
        public async Task<ApiResponse> DeleteAsync(DateTime date)
        {
            try
            {
                await _calendarDateService.RemoveHolidayAsync(date);
                return new ApiResponse();
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion
    }
}
