using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;


namespace UpdateMarkerColorService
{
    [Register(Policy.Transient, typeof(IUpdateMarkerColorService))]
    public class UpdateMarkerColorImpl : IUpdateMarkerColorService
    {
        IMarkerDAL _dal;
        IMessanger _wsService;

        public UpdateMarkerColorImpl(IMarkerDAL dal, IMessanger wsService)
        {
            _dal = dal;
            _wsService = wsService;
        }
        public Response UpdateMarkerColor(UpdateMarkerColorRequest request)
        {
            try
            {
                if (request.TypeOfColor == "BackColor")
                {
                    _dal.UpdateBackColorMarker(request.MarkerID, request.Color);
                }
                else
                {
                    _dal.UpdateForeColorMarker(request.MarkerID, request.Color);
                }
 
                MessageRequest msg = new MessageRequest(request.UserId, request.DocId, "markersUpdated");
                _wsService.Send(msg);
                var retval = new UpdateMarkerColorResponseOK();
                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
