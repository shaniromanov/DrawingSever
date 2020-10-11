using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;


namespace RemoveDocumentService
{
    [Register(Policy.Transient, typeof(IRemoveDocumentService))]
    public class RemoveDocumentImpl: IRemoveDocumentService
    {
        IDocumentDAL _dal;
        IMessanger _wsService;
        public RemoveDocumentImpl(IDocumentDAL dal, IMessanger wsService)
        {
            _dal = dal;
            _wsService = wsService;
        }

        public Response RemoveDocument(RemoveDocumentRequest request)
        {
            try
            {
                _dal.RemoveDocument(request.DocId);
                var retval = new RemoveDocumentResponseOK();
                MessageRequest msg = new MessageRequest(null, request.DocId, "documentDeleted");
                _wsService.Send(msg);
                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
