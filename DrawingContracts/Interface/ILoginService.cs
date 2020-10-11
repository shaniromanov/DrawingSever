using Contracts.DTO;
using DrawingContracts.DTO;

namespace DrawingContracts.Interface
{
   public interface ILoginService
    {
        Response Login(LoginRequest request);
    }
}
