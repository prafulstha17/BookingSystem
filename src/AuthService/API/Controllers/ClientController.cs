using Application.Interface.Client;
using Application.Modules.Clients;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepo _clientRepo;

        public ClientController(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClient([FromBody] InClient client)
        {
            var response = await _clientRepo.InClient(client);
            return response.Code == "200" ? Ok(response) : StatusCode(500, response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClient([FromBody] UpClient upClient)
        {
            var response = await _clientRepo.UpClient(upClient);
            return response.Code == "200" ? Ok(response) : StatusCode(500, response);
        }

        [HttpGet("query")]
        public async Task<IActionResult> QueryClient([FromQuery] InQryClient inQryClient)
        {
            var response = await _clientRepo.QryKitchen(inQryClient);
            return response.Code == "200" ? Ok(response) : StatusCode(500, response);
        }
    }
}