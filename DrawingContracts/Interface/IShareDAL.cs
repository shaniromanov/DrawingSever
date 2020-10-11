using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DrawingContracts.Interface
{
    public interface IShareDAL
    {
        DataSet CreateShare(string userId, string docId);
        DataSet RemoveShare(string userId, string docId);
        DataSet GetShareUser(string docId);
    }
}
