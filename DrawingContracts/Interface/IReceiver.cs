using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DrawingContracts.Interface
{
    public interface IReceiver
    {
        WebSocket WebSocket { get; set; }
        Task Start();
    }
}
