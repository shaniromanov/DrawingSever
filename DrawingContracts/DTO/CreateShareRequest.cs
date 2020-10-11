using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class CreateShareRequest
    {
        public string UserId { get; set; }
        public string DocId { get; set; }
    }
}
