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
    public class CreateMarkerController : ControllerBase
    {
        ICreateMarkerService _service;
        public CreateMarkerController(ICreateMarkerService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response CreateMarker([FromBody] CreateMarkerRequest request)
        {
            return _service.CreateMarker(request);
        }
    }
}
