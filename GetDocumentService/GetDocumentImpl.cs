using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDocumentService
{
    [Register(Policy.Transient, typeof(IGetDocumentService))]
    public class GetDocumentImpl: IGetDocumentService
    {
        IDocumentDAL _dal;
        public GetDocumentImpl(IDocumentDAL dal)
        {
            _dal = dal;
        }

        public Response GetDocument(GetDocumentRequest request)
        {
            try
            {
                var ds = _dal.GetDocument(request.DocId);
                GetDocumentResponse retval = new GetDocumentResponseDocumentNotExists();
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.DocId == (string)tbl.Rows[0][0])
                        {
                            retval = new GetDocumentResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1], (string)tbl.Rows[0][3], (string)tbl.Rows[0][4]);
                        }
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
