using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingSever.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class RemoveDocumentController : ControllerBase
    {
        IRemoveDocumentService _service;
        public RemoveDocumentController(IRemoveDocumentService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response RemoveDocument([FromBody] RemoveDocumentRequest request)
        {
            return _service.RemoveDocument(request);
        }
    }
}
