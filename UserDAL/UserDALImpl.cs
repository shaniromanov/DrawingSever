using Contracts;
using DALContracts;
using DrawingContracts.Interface;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using OracleDAL;
using System.Data;

namespace UserDAL
{
    [Register(Policy.Transient, typeof(IUserDAL))]
    public class UserDALImpl: IUserDAL
    {
        IDBConnection _conn;
        IInfraDAL _infraDAL;
        IConfiguration _configuration;
        public UserDALImpl(IInfraDAL infraDAL, IConfiguration configuration)
        {
            _configuration = configuration;
            var strConn = _configuration.GetConnectionString("DrawingAppDB");
            _infraDAL = infraDAL;
            _conn = _infraDAL.Connect(strConn);
        }
        public DataSet CreateUser(string id, string userName)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "CREATE_USER", _infraDAL.getParameter("p_id", "Varchar2", id),
                _infraDAL.getParameter("p_userName","Varchar2", userName), _infraDAL.getParameter("p_user","RefCursor", ParameterDirection.Output));
        }

        public DataSet RemoveUser(string id)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "MARK_USER_AS_REMOVED", _infraDAL.getParameter("p_id","Varchar2", id), _infraDAL.getParameter("p_user", "RefCursor", ParameterDirection.Output));
        }

        public DataSet GetUser(string id)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "GET_USER", _infraDAL.getParameter("p_id", "Varchar2", id), _infraDAL.getParameter("p_user", "RefCursor", ParameterDirection.Output));
        }
    }
}
