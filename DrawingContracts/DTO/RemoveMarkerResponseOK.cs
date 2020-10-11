using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class RemoveMarkerResponseOK: RemoveMarkerResponse
    {
        public RemoveMarkerResponseOK(string markerId)
        {
            MarkerId = markerId;
        }
        public string MarkerId { get; set; }
    }
}
