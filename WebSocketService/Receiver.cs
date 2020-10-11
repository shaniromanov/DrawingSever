using DrawingContracts.Interface;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WebSocketService
{
    public class Receiver: IReceiver
        
    {

        public WebSocket WebSocket { get; set; }

        public Messanger Messanger { get; set; }

        public string ReceiverId { get; set; }

        public Receiver(WebSocket webSocket, Messanger messanger, string receiverId)
        {
            Messanger = messanger;
            WebSocket = webSocket;
            ReceiverId = receiverId;
        }
        public async Task Start()
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            Console.WriteLine(result);
            while (!result.CloseStatus.HasValue)
            {
                await WebSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

                await WebSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                Messanger.ConnectionClose(ReceiverId, WebSocket);

     
        }
    }
}
