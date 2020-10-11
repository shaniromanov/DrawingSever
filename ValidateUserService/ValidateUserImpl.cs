using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;

namespace ValidateUserService
{
    [Register(Policy.Transient, typeof(IValidateUserService))]
    public class ValidateUserImpl: IValidateUserService
    {
        IUserDAL _dal;
        public ValidateUserImpl(IUserDAL dal)
        {
            _dal = dal;
        }

        public Response ValidateUser(ValidateUserRequest request)
        {
            try
            {
                var ds = _dal.GetUser(request.EmailAddress);
                ValidateUserResponseOK retval = new ValidateUserResponseOK();
                retval.UserNotExists = true;
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.EmailAddress == (string)tbl.Rows[0][0])
                        {
                            retval.UserNotExists = false;
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
