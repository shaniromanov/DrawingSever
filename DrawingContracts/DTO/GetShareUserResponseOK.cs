using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class GetShareUserResponseOK: GetShareUserResponse
    {
        public List<User> Users { get; set; }
        public GetShareUserResponseOK()
        {
            Users = new List<User>();
        }
    }
}
