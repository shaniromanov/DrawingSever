using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class RemoveShareRequest
    {
        public string UserId { get; set; }
        public string DocId { get; set; }
    }
}
