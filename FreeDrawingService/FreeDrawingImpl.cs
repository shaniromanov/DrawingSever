using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;


namespace FreeDrawingService
{
    [Register(Policy.Transient, typeof(IFreeDrawingService))]
    public class FreeDrawingImpl : IFreeDrawingService
    {
        DrawingContracts.Interface.IMessanger _wsService;
        public FreeDrawingImpl(IMessanger wsService)
        {
            _wsService = wsService;
        }

        public Response FreeDrawing(FreeDrawingRequest request)
        {
            MessageRequest msg = new MessageRequest(request.UserId, request.DocId+"/"+request.ClientX+"/"+request.ClientY+"/"+request.MovementX+"/"+request.MovementY, "Drawing");
            _wsService.Send(msg);
            return new FreeDrawingResponseOK();
        }
    }
}
