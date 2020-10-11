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
    public class RemoveShareController : ControllerBase
    {
        IRemoveShareService _service;
        public RemoveShareController(IRemoveShareService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response RemoveShare([FromBody] RemoveShareRequest request)
        {
            return _service.RemoveShare(request);
        }

    }
}
