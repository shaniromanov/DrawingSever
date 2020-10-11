using Contracts;
using DALContracts;
using DrawingContracts.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;


namespace MarkerDAL
{
    [Register(Policy.Transient, typeof(IMarkerDAL))]
    public class MarkerDALImpl: IMarkerDAL
    {
        IDBConnection _conn;
        IInfraDAL _infraDAL;
        IConfiguration _configuration;
        public MarkerDALImpl(IInfraDAL infraDAL, IConfiguration configuration)
        {
          
            _infraDAL = infraDAL;
            _configuration = configuration;
            var strConn = _configuration.GetConnectionString("DrawingAppDB");
            _conn = _infraDAL.Connect(strConn);

        }

        public DataSet CreateMarker(string id, string docId , string userID ,string markerType, decimal centerX,
                              decimal centerY, decimal radiusX, decimal radiusY, string foreColor, string backColor)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "CREATE_MARKER",
                _infraDAL.getParameter("p_id", "Varchar2", id),
                _infraDAL.getParameter("p_doc_id", "Varchar2", docId),
                _infraDAL.getParameter("p_user_id", "Varchar2", userID),
                _infraDAL.getParameter("p_marker_type", "Varchar2", markerType),
                _infraDAL.getParameter("p_center_x", "Varchar2", centerX),
                _infraDAL.getParameter("p_center_y", "Varchar2", centerY),
                _infraDAL.getParameter("p_radius_x", "Varchar2", radiusX),
                _infraDAL.getParameter("p_radius_y", "Varchar2", radiusY),
                _infraDAL.getParameter("p_fore_color", "Varchar2", foreColor),
                 _infraDAL.getParameter("p_back_color", "Varchar2", backColor)
                );
        }

        public DataSet GetMarkers(string DocId)
        {

            return _infraDAL.ExecuteSPQuery(_conn, "GET_MARKERS", _infraDAL.getParameter("p_doc_id", "Varchar2", DocId), _infraDAL.getParameter("p_out", "RefCursor", ParameterDirection.Output));
        }

        public DataSet RemoveMarker(string markerId)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVE_MARKER", _infraDAL.getParameter("p_id", "Varchar2", markerId));
        }

        public DataSet UpdateBackColorMarker(string markerId, string color)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "UPDATE_BACK_COLOR", _infraDAL.getParameter("p_id", "Varchar2", markerId), _infraDAL.getParameter("p_color", "Varchar2", color));
        }

        public DataSet UpdateForeColorMarker(string markerId, string color)
        {
            return _infraDAL.ExecuteSPQuery(_conn, "UPDATE_FORE_COLOR", _infraDAL.getParameter("p_id", "Varchar2", markerId), _infraDAL.getParameter("p_color", "Varchar2", color));
        }
    }
}
