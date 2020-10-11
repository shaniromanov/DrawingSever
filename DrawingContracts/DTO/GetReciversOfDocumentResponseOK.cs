using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class GetReciversOfDocumentResponseOK: GetReciversOfDocumentResponse
    {
        public List<string> Receivers { get; set; }
        public GetReciversOfDocumentResponseOK(List<string> users)
        {
            Receivers = new List<string>();
            if (users != null)
            {
                Receivers = users;
            }
        }
    }
}
