using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;


namespace RemoveShareService
{
    [Register(Policy.Transient, typeof(IRemoveShareService))]
    public class RemoveShareImpl: IRemoveShareService
    {
        IShareDAL _dal;
        IMessanger _wsService;
        public RemoveShareImpl(IShareDAL dal, IMessanger wsService)
        {
            _dal = dal;
            _wsService=wsService;
    }

        public Response RemoveShare(RemoveShareRequest request)
        {
            try
            {
                _dal.RemoveShare(request.UserId,request.DocId);
                var retval = new RemoveShareResponseOK();
                MessageRequest msg = new MessageRequest(request.UserId, request.DocId, "sharingDeleted");
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
