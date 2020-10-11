using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class RemoveMarkerRequest
    {
        public string MarkerId { get; set; }
        public string UserId { get; set; }
        public string DocId { get; set; }
    }
}
