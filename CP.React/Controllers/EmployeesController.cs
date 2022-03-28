using AutoWrapper.Wrappers;
using CP.BLL.DTOs;
using CP.BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CP.React.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        #region GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ApiResponse> GetAllAsync([FromQuery] int team)
        {
            try
            {
                var employees = await _employeeService.GetAllInTeamAsync(team);
                return new ApiResponse(employees);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ApiResponse> GetAsync(int id)
        {
            try
            {
                var employee = await _employeeService.GetAsync(id);
                return new ApiResponse(employee);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region GET: api/<EmployeesController>/5/absences
        [HttpGet("{id}/absences")]
        public async Task<ApiResponse> GetAllAbsencesAsync(int id)
        {
            try
            {
                var absences = await _employeeService.GetAllAbsencesAsync(id);
                return new ApiResponse(absences);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region POST api/<EmployeesController>
        [HttpPost]
        public async Task<ApiResponse> PostAsync([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = await _employeeService.CreateAsync(employeeDTO);
                return new ApiResponse(employee);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region POST api/<EmployeesController>/5/absences
        [HttpPost("{id}/absences")]
        public async Task<ApiResponse> PostAbsenceAsync(int id, [FromBody] AbsenceDTO absenceDTO)
        {
            if (!id.Equals(absenceDTO.EmployeeId))
            {
                return new ApiResponse("The IDs do not match", statusCode: 400);
            }
            try
            {
                await _employeeService.AddAbsenceAsync(id, absenceDTO);
                return new ApiResponse();
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<ApiResponse> PutAsync(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (!id.Equals(employeeDTO.Id))
            {
                return new ApiResponse(400, "idS DO NOT MATCH");
            }
            try
            {
                await _employeeService.UpdateAsync(id, employeeDTO);
                return new ApiResponse("EMPLOYEE UPDATED");
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                await _employeeService.DeleteAsync(id);
                return new ApiResponse("EMPLOYEE DELETED");
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region DELETE api/<EmployeesController>/5/absences
        [HttpDelete("{id}/absences")]
        public async Task<ApiResponse> DeleteAbsenceAsync(int id, [FromQuery] DateTime day)
        {
            try
            {
                await _employeeService.DeleteAbsenceAsync(id, day);
                return new ApiResponse("ABSENCE DELETED");
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
