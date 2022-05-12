using AutoWrapper.Wrappers;
using CP.BLL.DTOs;
using CP.BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CP.React.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly ITeamService _teamService;

        public TeamsController(ILogger<TeamsController> logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }

        #region GET: api/<TeamsController>
        [HttpGet]
        public async Task<ApiResponse> GetAsync()
        {
            try
            {
                var teams = await _teamService.GetAllAsync();
                return new ApiResponse(teams);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public async Task<ApiResponse> GetAsync(int id)
        {
            TeamDTO team;
            try
            {
                team = await _teamService.GetAsync(id);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
            return new ApiResponse(team);
        }
        #endregion

        #region POST api/<TeamsController>
        [HttpPost]
        public async Task<ApiResponse> PostAsync([FromBody] TeamDTO teamDTO)
        {
            TeamDTO team;
            try
            {
                team = await _teamService.CreateAsync(teamDTO);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
            return new ApiResponse(team);
        }
        #endregion

        #region PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public async Task<ApiResponse> PutAsync(int id, [FromBody] TeamDTO teamDTO)
        {
            if (!id.Equals(teamDTO.Id))
            {
                return new ApiResponse(400, "IDS DO NOT MATCH");
            }
            try
            {
                await _teamService.UpdateAsync(id, teamDTO);
                return new ApiResponse();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                await _teamService.DeleteAsync(id);
                return new ApiResponse("TEAM DELETED");
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
