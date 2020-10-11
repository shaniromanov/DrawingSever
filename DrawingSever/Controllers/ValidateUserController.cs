using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingSever.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class ValidateUserController : ControllerBase
    {
        IValidateUserService _service;
        public ValidateUserController(IValidateUserService service)
        {
            _service = service;
        }


        [HttpPost]
        public Response ValidateUser([FromBody] ValidateUserRequest request)
        {

            return _service.ValidateUser(request);
        }
    }
}
