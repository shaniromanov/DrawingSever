using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class Marker
    {
        public string MarkerId { get; set; }
        public string DocId { get; set; }
        public string UserID { get; set; }
        public string MarkerType { get; set; }
        public decimal CenterX { get; set; }
        public decimal CenterY { get; set; }
        public decimal RadiusX { get; set; }
        public decimal RadiusY { get; set; }
        public string ForeColor { get; set; }
        public string BackColor { get; set; }
    }
}
