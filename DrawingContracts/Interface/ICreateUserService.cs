using Contracts.DTO;
using DrawingContracts.DTO;

namespace DrawingContracts.Interface
{
    public interface ICreateUserService
    {
        Response CreateUser(CreateUserRequest request);
    }
}
