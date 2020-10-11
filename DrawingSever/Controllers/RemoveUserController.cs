using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingSever.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class RemoveUserController : ControllerBase
    {
        IRemoveUserService _service;
        public RemoveUserController(IRemoveUserService service)
        {
            _service = service;
        }


        [HttpPost]
        public Response RemoveUser([FromBody] RemoveUserRequest request)
        {
            return _service.RemoveUser(request);
        }
    }
}
