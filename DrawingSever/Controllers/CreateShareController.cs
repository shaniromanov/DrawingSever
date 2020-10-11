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
    public class CreateShareController : ControllerBase
    {
        ICreateShareService _service;
        public CreateShareController(ICreateShareService service)
        {
            _service = service;
        }


        [HttpPost]
        public Response CreateShare([FromBody] CreateShareRequest request)
        {
            return _service.CreateShare(request);
        }
    }
}
