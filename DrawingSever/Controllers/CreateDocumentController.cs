using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingSever.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class CreateDocumentController : ControllerBase
    {
        ICreateDocumentService _service;
        public CreateDocumentController(ICreateDocumentService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response CreateDocument([FromBody] CreateDocumentRequest request)
        {
            return _service.CreateDocument(request);
        }
    }
}
