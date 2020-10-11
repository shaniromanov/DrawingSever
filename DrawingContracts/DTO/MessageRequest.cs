using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class MessageRequest
    {
        public string ID { get; set; }
        public string DocID { get; set; }
        public string Type { get; set; }
        public MessageRequest(string id ,string docID,string type)
        {
            ID = id;
            DocID = docID;
            Type = type;
        }
    }
}
