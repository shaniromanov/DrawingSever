
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingSever.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UpdateMarkerColorController : ControllerBase
    {
        IUpdateMarkerColorService _service;
        public UpdateMarkerColorController(IUpdateMarkerColorService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response UpdateMarkerColor([FromBody] UpdateMarkerColorRequest request)
        {
            return _service.UpdateMarkerColor(request);
        }
    }
}
