using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;

namespace LoginService
{
    [Register(Policy.Transient, typeof(ILoginService))]
    public class LoginServiceImpl : ILoginService
    {
        IUserDAL _dal;
        public LoginServiceImpl(IUserDAL dal)
        {
            _dal = dal;
        }
        public Response Login(LoginRequest request)
        {
            try
            {
                var ds = _dal.GetUser(request.EmailAddress);
                LoginResponse retval = new LoginResponseUserNotExists();
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.EmailAddress == (string)tbl.Rows[0][0])
                        {
                            retval = new LoginResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1]);
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
