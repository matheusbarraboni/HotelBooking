using Application;
using Application.Guest.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> logger;
        private readonly IConsumerPort ports;

        public GuestController(ILogger<GuestController> logger, IConsumerPort ports)
        {
            this.logger = logger;
            this.ports = ports;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO guest)
        {
            var response = await ports.CreateGuest(guest);

            if(response.Success) return Created("", response.Data);

            logger.LogError("Error while processing the request", response);
            return Problem(response.Message);

        }
    }
}
