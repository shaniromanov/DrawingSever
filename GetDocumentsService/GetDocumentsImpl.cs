using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;
using System.Data;

namespace GetDocumentsService
{
    [Register(Policy.Transient, typeof(IGetDocumentsService))]
    public class GetDocumentsImpl : IGetDocumentsService
    {
        IDocumentDAL _dal;
        public GetDocumentsImpl(IDocumentDAL dal)
        {
            _dal = dal;
        }
        public Response GetDocuments(string request)
        {
            try
            {

                var docDs = _dal.GetDocuments(request);
                GetDocumentsResponseOK retval = new GetDocumentsResponseOK();
                if (docDs.Tables.Count > 0)
                {
                    var tbl = docDs.Tables[0];
                    foreach (DataRow row in tbl.Rows)
                    {
                        Document doc = new Document();
                        doc.Owner = (string)row[0];
                        if (row[1] is System.DBNull)
                        {
                            doc.ImageUrl = "";
                        }
                        else
                        {
                            doc.ImageUrl = (string)row[1];
                        }
                        doc.DocumemtName = (string)row[2];
                        doc.DocID = (string)row[3];
                        retval.MyDocuments.Add(doc);
                    }
                }


                var sharedDs = _dal.GetSharedDocuments(request);
                if (sharedDs.Tables.Count > 0)
                {
                    var tbl = sharedDs.Tables[0];
                    foreach (DataRow row in tbl.Rows)
                    {
                        Document doc = new Document();
                        doc.Owner = (string)row[0];
                        if (row[1] is System.DBNull)
                        {
                            doc.ImageUrl = "";
                        }
                        else
                        {
                            doc.ImageUrl = (string)row[1];
                        } 
                        doc.DocumemtName = (string)row[2];
                        doc.DocID = (string)row[3];
                        retval.SharedDocuments.Add(doc);
                    }
                }
                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
