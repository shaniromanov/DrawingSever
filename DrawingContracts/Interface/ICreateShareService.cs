using Contracts.DTO;
using DrawingContracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingContracts.Interface
{
    public interface ICreateShareService
    {
        Response CreateShare(CreateShareRequest request);
    }
}
