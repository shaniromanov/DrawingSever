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
    public class GetMarkersController : ControllerBase
    {
        IGetMarkersService _service;
        public GetMarkersController(IGetMarkersService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response GetMarkers(GetMarkersRequest request)
        {

            return _service.GetMarkers(request);
        }
    }
}
