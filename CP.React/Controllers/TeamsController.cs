using CP.BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CP.React.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly ITeamService _teamService;

        public TeamsController(ILogger<TeamsController> logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }

        // GET: api/<TeamsController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var teams = await _teamService.GetAllAsync();
            _logger.LogInformation($"RETURNED {teams.Count} TEAMS");
            return Ok(teams);
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var team = await _teamService.GetOneAsync(id);
            return Ok(team);
        }

        // POST api/<TeamsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TeamDTO teamDTO)
        {
            TeamDTO team = await _teamService.CreateAsync(teamDTO);
            return Ok(team);
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] TeamDTO teamDTO)
        {
            if (!id.Equals(teamDTO.Id))
            {
                return BadRequest();
            }
            try
            {
                await _teamService.UpdateAsync(id, teamDTO);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                return BadRequest(exc.Message);
            }
            return NoContent();
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _teamService.DeleteAsync(id);
                _logger.LogInformation($"TEAM WITH ID {id} DELETED");
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                return BadRequest(exc.Message);
            }
            return NoContent();
        }
    }
}
