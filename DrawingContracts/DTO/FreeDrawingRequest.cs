using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class FreeDrawingRequest
    {
        public string DocId { get; set; }
        public string UserId { get; set; }
        public decimal ClientX { get; set; }
        public decimal ClientY { get; set; }
        public decimal MovementX { get; set; }
        public decimal MovementY { get; set; }
    }
}
