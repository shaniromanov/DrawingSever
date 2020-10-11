using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DrawingContracts.Interface
{
    public interface IDocumentDAL
    {
        DataSet CreateDocument(string id, string ownerId, string name);
        DataSet GetDocument(string id);
        DataSet RemoveDocument(string id);
        DataSet GetDocuments(string OwnerId);
        DataSet GetSharedDocuments(string userId);
        DataSet UpdateImageUrl(string id, string url);
    }
}
