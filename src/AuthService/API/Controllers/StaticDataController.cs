using Application.Interface.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticDataController : ControllerBase
    {
        private readonly IStaticDataRepository _staticDataRepository;
        public StaticDataController(IStaticDataRepository staticDataRepository)
        {
            _staticDataRepository = staticDataRepository;
        }
        [HttpGet("GetByKey/{key}")]
        public async Task<IActionResult> GetByKey(string key)
        {
            var result = await _staticDataRepository.GetByKeyAsync(key);
            if (result.Code == "200")
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
