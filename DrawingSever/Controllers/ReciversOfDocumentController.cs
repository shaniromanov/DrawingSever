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
    public class ReciversOfDocumentController : ControllerBase
    {
        IOnDocumentSharing _service;
        public ReciversOfDocumentController(IOnDocumentSharing service)
        {
            _service = service;
        }

        [HttpPost]
        public Response DocumentSharing(DocumentSharingRequest request)
        {

            return _service.DocumentSharing(request);
        }
        [HttpPost]
        public Response GetReciversOfDocument(GetReciversOfDocumentRequest request)
        {

            return _service.GetReciversOfDocument(request);
        }

     

        [HttpPost]
        public Response StopDocumentSharing(DocumentSharingRequest request)
        {

            return _service.StopDocumentSharing(request);
        }

    }
}
