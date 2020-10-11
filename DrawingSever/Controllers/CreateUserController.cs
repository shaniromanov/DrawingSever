using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using Microsoft.AspNetCore.Mvc;


namespace DrawingSever.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class CreateUserController : ControllerBase
    {
        ICreateUserService _service;
        public CreateUserController(ICreateUserService service)
        {
            _service = service;
        }


        [HttpPost]
        public Response SignUp( CreateUserRequest request)
        {
            return _service.CreateUser(request);
        }
    }
}
