using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;
using System.Data;

namespace GetShareUserService
{
    [Register(Policy.Transient, typeof(IGetShareUserService))]
    public class GetShareUserImpl: IGetShareUserService
    {
        IShareDAL _dal;
        public GetShareUserImpl(IShareDAL dal)
        {
            _dal = dal;
        }
        public Response GetShareUser(GetShareUserRequest request)
        {
            try
            {
                var userDs =_dal.GetShareUser(request.DocId);
                var retval = new GetShareUserResponseOK();
                if (userDs.Tables.Count > 0)
                {
                    var tbl = userDs.Tables[0];
                    foreach (DataRow row in tbl.Rows)
                    {
                        User user = new User();
                        user.EmailAddress = (string)row[0];
                        user.UserName = (string)row[1];
                        retval.Users.Add(user);
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
