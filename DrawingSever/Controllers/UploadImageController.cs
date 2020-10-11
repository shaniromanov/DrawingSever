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
    public class UploadImageController : ControllerBase
    {
        IUploadImageService _service;
        public UploadImageController(IUploadImageService service)
        {
            _service = service;
        }

        [HttpPost]
        public Response UploadImage([FromForm] UploadImageRequest request)
        {

            return _service.UploadImage(request);
        }
    }
}
