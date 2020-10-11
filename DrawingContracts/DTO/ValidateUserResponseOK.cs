using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.DTO
{
    public class ValidateUserResponseOK: ValidateUserResponse
    {
        public bool UserNotExists { get; set; }
    }
}
