using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using ObserverService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OnDocumentSharing
{
    [Register(Policy.Singleton, typeof(IOnDocumentSharing))]
    public class OnDocumentSharingImpl:Observer, IOnDocumentSharing
    {
        IMessanger _wsService;
        public Dictionary<string, List<string>> OpenDocumentSharing { get; set; }
        public OnDocumentSharingImpl(IMessanger wsService):base(wsService)
        {
            _wsService = wsService;
            _wsService.Attach(this);
            OpenDocumentSharing = new Dictionary<string, List<string>>();
        }
        public Response DocumentSharing(DocumentSharingRequest request)
        {
            if (OpenDocumentSharing.ContainsKey(request.DocId))
            {
                OpenDocumentSharing[request.DocId].Add(request.UserId);
            }
            else
            {
                OpenDocumentSharing[request.DocId] = new List<string>();
                OpenDocumentSharing[request.DocId].Add(request.UserId);
            }
            MessageRequest req = new MessageRequest(request.UserId, request.DocId, "NewDocumentSharing");
           _wsService.Send(req);
            return new DocumentSharingChangeResponseOK();

        }
        public Response StopDocumentSharing(DocumentSharingRequest request)
        {
            OpenDocumentSharing[request.DocId].Remove(request.UserId);
            MessageRequest req = new MessageRequest(request.UserId, request.DocId, "RemoveDocumentSharing");
            _wsService.Send(req);
            return new DocumentSharingChangeResponseOK();
        }
        public Response GetReciversOfDocument(GetReciversOfDocumentRequest request)
        {
            GetReciversOfDocumentResponse retval;
            try
            {
                retval = new GetReciversOfDocumentResponseOK(OpenDocumentSharing[request.DocId]);
                return retval;
             
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }

        public override void Update(string data)
        {
            foreach(var doc in OpenDocumentSharing)
            {
                if (doc.Value.Contains(data))
                {
                    var index=doc.Value.IndexOf(data);
                    doc.Value.RemoveAt(index);
                    MessageRequest msg = new MessageRequest(data,null, "RemoveDocumentSharing");
                    _wsService.Send(msg);
                }   
            }
        }
    }
}
