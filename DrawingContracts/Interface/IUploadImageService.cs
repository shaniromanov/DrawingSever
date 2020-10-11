using Contracts.DTO;
using DrawingContracts.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.Interface
{
    public interface IUploadImageService
    {
        Response UploadImage(UploadImageRequest request);
    }
}
