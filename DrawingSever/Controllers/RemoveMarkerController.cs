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
    public class RemoveMarkerController : ControllerBase
    {
        IRemoveMarkerService _service;
        public RemoveMarkerController(IRemoveMarkerService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response RemoveMarker([FromBody] RemoveMarkerRequest request)
        {
            return _service.RemoveMarker(request);
        }
    }
}
