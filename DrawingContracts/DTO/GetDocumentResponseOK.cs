using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class GetDocumentResponseOK: GetDocumentResponse
    {
        public GetDocumentResponseOK(string id, string owner, string name, string img)
        {
            Doc.DocID = id;
            Doc.Owner = owner;
            Doc.DocumemtName = name;
            Doc.ImageUrl = img;
        }
        public Document Doc { get; set; }
 
    }
}
