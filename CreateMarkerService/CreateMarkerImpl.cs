using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using GenerateIdContracts;
using System;


namespace CreateMarkerService
{
    [Register(Policy.Transient, typeof(ICreateMarkerService))]
    public class CreateMarkerImpl : ICreateMarkerService
    {
        IMarkerDAL _dal;
        IGenerateIdService _idGeneretor;
        IMessanger _wsService;
        public CreateMarkerImpl(IMarkerDAL dal, IGenerateIdService idGeneretor, IMessanger wsService)
        {
            _dal = dal;
            _idGeneretor = idGeneretor;
            _wsService = wsService;
        }
        public Response CreateMarker(CreateMarkerRequest request)
        {
            try
            {
                var id = _idGeneretor.GenerateId(request.DocId+request.UserID);
                var ds = _dal.CreateMarker(id, request.DocId, request.UserID,request.MarkerType,request.CenterX,request.CenterY,request.RadiusX,request.RadiusY,request.ForeColor,request.BackColor);
                Marker marker = new Marker();
                marker.MarkerId = id;
                marker.DocId = request.DocId;
                marker.UserID = request.UserID;
                marker.MarkerType = request.MarkerType;
                marker.CenterX = request.CenterX;
                marker.CenterY = request.CenterY;
                marker.RadiusX = request.RadiusX;
                marker.RadiusY = request.RadiusY;
                marker.ForeColor = request.ForeColor;
                marker.BackColor = request.BackColor;
                MessageRequest msg = new MessageRequest(request.UserID, request.DocId, "markersUpdated");
                _wsService.Send(msg);
                return new CreateMarkerResponseOK(marker);
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
