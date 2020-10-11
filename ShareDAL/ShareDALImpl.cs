using Contracts;
using DALContracts;
using DrawingContracts.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace ShareDAL
{
    [Register(Policy.Transient, typeof(IShareDAL))]
    public class ShareDALImpl: IShareDAL
    {
        IDBConnection _conn;
        IInfraDAL _infraDAL;
        IConfiguration _configuration;
        public ShareDALImpl(IInfraDAL infraDAL, IConfiguration configuration)
        {
            _configuration = configuration;
            var strConn = _configuration.GetConnectionString("DrawingAppDB");
            _infraDAL = infraDAL;
            _conn = _infraDAL.Connect(strConn);
        }

        public DataSet CreateShare(string userId, string docId)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "CREATE_SHARE", _infraDAL.getParameter("p_user_id", "Varchar2", userId),
                _infraDAL.getParameter("p_doc_id", "Varchar2", docId));
        }
        
        public DataSet RemoveShare(string userId, string docId)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVE_SHARE", _infraDAL.getParameter("p_user_id", "Varchar2", userId),
                _infraDAL.getParameter("p_doc_id", "Varchar2", docId));
        }
        public DataSet GetShareUser(string docId)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "GET_SHARE_USER",_infraDAL.getParameter("p_id", "Varchar2", docId), _infraDAL.getParameter("p_out", "RefCursor", ParameterDirection.Output));
        }

    }
}
