using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class UploadImageRequest
    {
        public IFormFile Image { get; set; }
        public string DocId { get; set; }
    }
}
