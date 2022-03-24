using AutoWrapper.Wrappers;
using CP.BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CP.React.Controllers
{
    [ApiController]
    [Route("api/regimes")]
    public class RegimesController : ControllerBase
    {
        private readonly ILogger<RegimesController> _logger;
        private readonly IRegimeService _regimeService;

        public RegimesController(ILogger<RegimesController> logger, IRegimeService regimeService)
        {
            _logger = logger;
            _regimeService = regimeService;
        }

        #region GET: api/<RegimesController>
        [HttpGet]
        public async Task<ApiResponse> GetAsync()
        {
            try
            {
                var regimes = await _regimeService.GetAllAsync();
                return new ApiResponse(regimes);
            }
            catch (Exception exc)
            {
                _logger.LogError("{msg}", exc.Message);
                throw new ApiException(exc);
            }
        }
        #endregion

        #region GET api/<RegimesController>/5
        [HttpGet("{id}")]
        public async Task<ApiResponse> GetAsync(int id)
        {
            try
            {
                var regime = await _regimeService.GetAsync(id);
                return new ApiResponse(regime);
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
