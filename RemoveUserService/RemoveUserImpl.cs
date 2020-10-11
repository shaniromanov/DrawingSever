using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;

namespace RemoveUserService
{
    [Register(Policy.Transient, typeof(IRemoveUserService))]
    public class RemoveUserImpl: IRemoveUserService
    {
        IUserDAL _dal;
        public RemoveUserImpl(IUserDAL dal)
        {
            _dal = dal;
        }

        public Response RemoveUser(RemoveUserRequest request)
        {
            try
            {
                _dal.RemoveUser(request.EmailAddress);
                var retval = new RemoveUserResponseOK();
                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
