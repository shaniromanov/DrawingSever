
using Contracts.DTO;
using ImageServiceCoreContracts.DTO;
using ImageServiceCoreContracts.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceCore
{

        public class ImageWriter : IImageWriter
        {
            public async Task<string> UploadImage(IFormFile file)
            {
            var retval = "";
                if (CheckIfImageFile(file))
                {

                retval= await WriteFile(file);
                }

                return retval;
            }

            /// Method to check if file is image file

            private bool CheckIfImageFile(IFormFile file)
            {
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                return ImageFileValidator.GetImageFormat(fileBytes) != ImageFileValidator.ImageFormat.unknown;
            }


            /// Method to write file onto the disk

            public async Task<string> WriteFile(IFormFile file)
            {
                string fileName;
                try
                {
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    fileName = Guid.NewGuid().ToString() + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);

                    using (var bits = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(bits);
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }

                return "https://localhost:44384/Images/" + fileName;
            }
        }
        
}
