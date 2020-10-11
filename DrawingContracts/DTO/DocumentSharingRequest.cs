using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class DocumentSharingRequest
    {
        public string DocId { get; set; }
        public string UserId { get; set; }
    }
}
