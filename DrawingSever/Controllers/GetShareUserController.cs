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
    public class GetShareUserController : ControllerBase
    {
        IGetShareUserService _service;
        public GetShareUserController(IGetShareUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response GetShareUser(GetShareUserRequest request)
        {

            return _service.GetShareUser(request);
        }
    }
}
