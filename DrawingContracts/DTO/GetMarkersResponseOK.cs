using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class GetMarkersResponseOK: GetMarkersResponse
    {
        public GetMarkersResponseOK()
        {
            Markers = new List<Marker>();
        }
        public List<Marker> Markers { get; set; }
    }
}
