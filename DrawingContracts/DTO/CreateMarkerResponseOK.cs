using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    
   public class CreateMarkerResponseOK: CreateMarkerResponse
    {
        public Marker Marker { get; set; }
        public CreateMarkerResponseOK(Marker marker)
        {
            Marker = marker;
        }
    }
}
