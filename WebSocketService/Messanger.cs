using Contracts;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using ObserverService;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WebSocketService
{
    [Register(Policy.Singleton, typeof(IMessanger))]
    public class Messanger:Subject,IMessanger
    {
        public Dictionary<string,IReceiver> _receivers { get; set; }

        public Messanger()
        {
            _receivers = new Dictionary<string, IReceiver>();
        }
        public async Task Send(MessageRequest request)
        {
 
                foreach(var rec in _receivers)
                {
                    if (rec.Key != request.ID||request.Type== "sharingDeleted")
                    {
                        var buffer = Encoding.UTF8.GetBytes(request.Type + " " + request.ID+" "+request.DocID);
                        await rec.Value.WebSocket.SendAsync(new ReadOnlyMemory<byte>(buffer), WebSocketMessageType.Text
                                         , true
                                        , CancellationToken.None);
                    }
                }

        }
        public IReceiver AddOrRemove(string id, string type, WebSocket socket)
        {
            IReceiver retval = null;
            if (type == "connection")
            {
                if (!_receivers.ContainsKey(id))
                {
                    _receivers[id] = new Receiver(socket,this,id);
                    retval = _receivers[id];
                }
            }
            else
            {
                _receivers.Remove(id);
            }
    
            return retval;
        }


        public async void ConnectionClose(string receiverId, WebSocket socket)
        {
                    if (_receivers.ContainsKey(receiverId))
                    {
                        AddOrRemove(receiverId, "disconnection", socket);
                        MessageRequest request = new MessageRequest(receiverId, null, "disconnection");
                        await Send(request);
                    }
            Notify(receiverId);
                
        }
    }
}
