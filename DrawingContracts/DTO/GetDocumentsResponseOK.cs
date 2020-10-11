using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class GetDocumentsResponseOK: GetDocumentsResponse
    {
        public GetDocumentsResponseOK()
        {
            MyDocuments = new List<Document>();
            SharedDocuments = new List<Document>();
        }
        public List<Document> MyDocuments { get; set; }
        public List<Document> SharedDocuments { get; set; }
    }
}
