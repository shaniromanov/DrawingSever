using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;

namespace SignUpService
{
    [Register(Policy.Transient, typeof(ISignUpService))]
    public class SignUpImpl: ISignUpService
    {
        IUserDAL _dal;
        public SignUpImpl(IUserDAL dal)
        {
            _dal = dal;
        }

        public Response SignUp(SignUpRequest request)
        {
            try
            {
                var ds = _dal.CreateUser(request.EmailAddress, request.UserName); 
                SignUpResponse retval = new SignUpResponseEmailAddressExists();
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.EmailAddress == (string)tbl.Rows[0][0]
                            && request.UserName == (string)tbl.Rows[0][1])
                        {
                            retval = new SignUpResponseOK();
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
