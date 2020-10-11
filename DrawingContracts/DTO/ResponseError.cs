using Contracts.DTO;

namespace DrawingContracts.DTO
{
    public class ResponseError:Response
    {
        public string Message { get; }
        public ResponseError(string msg)
        {
            Message = msg;
        }
    }
}
