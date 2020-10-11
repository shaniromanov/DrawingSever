using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;


namespace RemoveMarkerService
{
    [Register(Policy.Transient, typeof(IRemoveMarkerService))]
    public class RemoveMarkerImpl : IRemoveMarkerService
    {
        IMarkerDAL _dal;
        IMessanger _wsService;
        public RemoveMarkerImpl(IMarkerDAL dal, IMessanger wsService)
        {
            _dal = dal;
            _wsService = wsService;
        }
        public Response RemoveMarker(RemoveMarkerRequest request)
        {
            try
            {
                _dal.RemoveMarker(request.MarkerId);
                MessageRequest msg = new MessageRequest(request.UserId, request.DocId, "markersUpdated");
                _wsService.Send(msg);
                var retval = new RemoveMarkerResponseOK(request.MarkerId);
                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
