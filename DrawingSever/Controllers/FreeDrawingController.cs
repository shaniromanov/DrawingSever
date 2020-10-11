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
    public class FreeDrawingController : ControllerBase
    {
        IFreeDrawingService _service;
        public FreeDrawingController(IFreeDrawingService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response FreeDrawing(FreeDrawingRequest request)
        {
            return _service.FreeDrawing(request);
        }
    }
}
