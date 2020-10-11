using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class CreateDocumentResponseOK: CreateDocumentResponse
    {
        public string DocId { get; set; }
        public CreateDocumentResponseOK(string id)
        {
            DocId = id;
        }
    }
}
