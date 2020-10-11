using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using ImageServiceCore;
using ImageServiceCoreContracts.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace UploadImageService
{
    [Register(Policy.Transient, typeof(IUploadImageService))]
    public class UploadImageImpl : IUploadImageService
    {
        IImageWriter _imageWriter;
        IDocumentDAL _dal;
        public UploadImageImpl(IImageWriter imageWriter, IDocumentDAL dal)
        {
            _imageWriter = imageWriter;
            _dal = dal;
        }
        public Response UploadImage(UploadImageRequest request)
        {
            try
            {
                UploadImageResponse retval = new UploadImageResponseInvalidImageFile();
                var imageUrl= _imageWriter.UploadImage(request.Image);
                if (imageUrl.Result!="")
                {
                retval = new UploadImageResponseOK(imageUrl.Result);
                    _dal.UpdateImageUrl(request.DocId, imageUrl.Result);
                }
                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
