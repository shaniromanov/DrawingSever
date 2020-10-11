using Contracts.DTO;
using DrawingContracts.DTO;

namespace DrawingContracts.Interface
{
    public interface IRemoveUserService
    {
        Response RemoveUser(RemoveUserRequest request);
    }
}
