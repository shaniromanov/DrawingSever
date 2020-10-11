using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class UpdateMarkerColorRequest
    {
        public string TypeOfColor { get; set; }
        public string MarkerID { get; set; }
        public string Color { get; set; }
        public string UserId { get; set; }
        public string DocId { get; set; }
    }
}
