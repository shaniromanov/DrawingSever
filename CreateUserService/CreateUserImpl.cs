using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;

namespace CreateUserService
{
    [Register(Policy.Transient, typeof(ICreateUserService))]
    public class CreateUserImpl : ICreateUserService
    {
        IUserDAL _dal;
        public CreateUserImpl(IUserDAL dal)
        {
            _dal = dal;
        }

        public Response CreateUser(CreateUserRequest request)
        {
            try
            {
                
                
                CreateUserResponse retval = new CreateUserResponseEmailAddressExists();
                var userExists = _dal.GetUser(request.EmailAddress);
                if (userExists.Tables.Count > 0)
                {
                    var tbl = userExists.Tables[0];
                    if (tbl.Rows.Count == 0)
                    {
                        var ds = _dal.CreateUser(request.EmailAddress, request.UserName);
                        var tb = ds.Tables[0];
                        if (request.EmailAddress == (string)tb.Rows[0][0]
                            && request.UserName == (string)tb.Rows[0][1])
                        {
                            retval = new CreateUserResponseOK();
                        }
                    }
                }
                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
