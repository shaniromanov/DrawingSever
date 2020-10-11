using Contracts;
using DALContracts;
using DrawingContracts.Interface;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using OracleDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocumentDAL
{
    [Register(Policy.Transient, typeof(IDocumentDAL))]
    public class DocumentDALImpl : IDocumentDAL
    {
        IDBConnection _conn;
        IInfraDAL _infraDAL;
        IConfiguration _configuration;
        public DocumentDALImpl(IInfraDAL infraDAL, IConfiguration configuration)
        {
            _configuration = configuration;
            var strConn = _configuration.GetConnectionString("DrawingAppDB");
            _infraDAL = infraDAL;
            _conn = _infraDAL.Connect(strConn);

        }

        public DataSet CreateDocument(string id, string ownerId, string name)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "CREATE_DOCUMENT",
                _infraDAL.getParameter("p_id", "Varchar2", id),
                _infraDAL.getParameter("p_owner", "Varchar2", ownerId),
                _infraDAL.getParameter("p_name", "Varchar2", name));
        }
        public DataSet GetDocument(string id)
        {

            return _infraDAL.ExecuteSPQuery(_conn, "GET_DOCUMENT", _infraDAL.getParameter("p_id", "Varchar2", id), _infraDAL.getParameter("p_user", "RefCursor", ParameterDirection.Output));
        }

        public DataSet RemoveDocument(string id)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVE_DOCUMENT", _infraDAL.getParameter("p_id", "Varchar2", id));
        }

        public DataSet GetDocuments(string OwnerId)
        {

            return _infraDAL.ExecuteSPQuery(_conn, "GET_DOCUMENTS", _infraDAL.getParameter("p_id", "Varchar2", OwnerId), _infraDAL.getParameter("p_out", "RefCursor", ParameterDirection.Output));
        }

        public DataSet GetSharedDocuments(string userId)
        {

            return _infraDAL.ExecuteSPQuery(_conn, "GET_SHAREDDOCUMENTS", _infraDAL.getParameter("p_id", "Varchar2", userId), _infraDAL.getParameter("p_out", "RefCursor", ParameterDirection.Output));
        }
        public DataSet UpdateImageUrl(string id,string url)
        {

            return _infraDAL.ExecuteSPQuery(_conn, "UPDATE_IMAGE_URL", _infraDAL.getParameter("p_id", "Varchar2", id), _infraDAL.getParameter("p_url", "Varchar2", url));
        }
        
    }
}
