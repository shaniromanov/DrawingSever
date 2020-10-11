using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;


namespace CreateShareService
{
    [Register(Policy.Transient, typeof(ICreateShareService))]
    public class CreateShareImpl: ICreateShareService
    {
        IShareDAL _dal;
        IUserDAL _userDal;
        IMessanger _wsService;

        public CreateShareImpl(IShareDAL dal,IUserDAL userDAL, IMessanger wsService)
        {
            _dal = dal;
            _userDal = userDAL;
            _wsService = wsService;
        }

        public Response CreateShare(CreateShareRequest request)
        {
            try
            {
                CreateShareResponse retval = new CreateShareResponseUserNotExists();
                
                var userExists = _userDal.GetUser(request.UserId);
                if (userExists.Tables.Count > 0)
                {
                    var tbl = userExists.Tables[0];
                    if (tbl.Rows.Count > 0)
                    {
                        var ds = _dal.CreateShare(request.UserId, request.DocId);
                        MessageRequest msg = new MessageRequest(null, request.DocId, "sharingAdded");
                        _wsService.Send(msg);
                        retval = new CreateShareResponseOK();
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
