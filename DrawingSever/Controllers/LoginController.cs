using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingSever.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }


        [HttpPost]
        public Response Login([FromBody] LoginRequest request)
        {
            
            return _service.Login(request);
        }
    }
}
