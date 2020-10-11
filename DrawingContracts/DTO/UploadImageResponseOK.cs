
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class UploadImageResponseOK: UploadImageResponse
    {
        public UploadImageResponseOK(string fileUrl)
        {
            ImageUrl = fileUrl;
        }
        public string ImageUrl { get; set; }
    }
}
