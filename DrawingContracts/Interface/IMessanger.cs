
using DrawingContracts.DTO;
using ObserverContracts;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DrawingContracts.Interface
{
    public interface IMessanger:ISubject
    {
        Dictionary<string, IReceiver> _receivers { get; set; }
        Task Send(MessageRequest request);
        IReceiver AddOrRemove(string id, string type, WebSocket socke);
    }
}
