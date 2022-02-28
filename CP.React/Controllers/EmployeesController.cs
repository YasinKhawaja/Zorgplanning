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
        public async Task<ApiResponse> GetAllAsync([FromQuery] int teamKey)
        {
            try
            {
                var employees = await _employeeService.GetAllInTeamAsync(teamKey);
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
        [HttpGet("{key}")]
        public async Task<ApiResponse> GetAsync(int key)
        {
            try
            {
                var employee = await _employeeService.GetAsync(key);
                return new ApiResponse(employee);
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

        #region PUT api/<EmployeesController>/5
        [HttpPut("{key}")]
        public async Task<ApiResponse> PutAsync(int key, [FromBody] EmployeeDTO employeeDTO)
        {
            if (!key.Equals(employeeDTO.Id))
            {
                return new ApiResponse(400, "KEYS DO NOT MATCH");
            }
            try
            {
                await _employeeService.UpdateAsync(key, employeeDTO);
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
        [HttpDelete("{key}")]
        public async Task<ApiResponse> DeleteAsync(int key)
        {
            try
            {
                await _employeeService.DeleteAsync(key);
                return new ApiResponse("EMPLOYEE DELETED");
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
