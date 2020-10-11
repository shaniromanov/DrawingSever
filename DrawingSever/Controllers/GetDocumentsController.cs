using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingSever.Controllers
{
    //[Route("api/[controller]/{action}")]
    [ApiController]
    public class GetDocumentsController : ControllerBase
    {
        IGetDocumentsService _service;
        public GetDocumentsController(IGetDocumentsService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("api/GetDocuments/GetDocuments/{request}")]
        public Response GetDocuments(string request)
        {

            return _service.GetDocuments(request);
        }
    }
}
