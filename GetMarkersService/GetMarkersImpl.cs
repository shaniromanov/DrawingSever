using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using System;
using System.Data;

namespace GetMarkersService
{
    [Register(Policy.Transient, typeof(IGetMarkersService))]
    public class GetMarkersImpl : IGetMarkersService
    {
        IMarkerDAL _dal;
        public GetMarkersImpl(IMarkerDAL dal)
        {
            _dal = dal;
        }
        public Response GetMarkers(GetMarkersRequest request)
        {
            try
            {

                var docDs = _dal.GetMarkers(request.DocId);
                GetMarkersResponseOK retval = new GetMarkersResponseOK();
                if (docDs.Tables.Count > 0)
                {
                    var tbl = docDs.Tables[0];
                    foreach (DataRow row in tbl.Rows)
                    {
                        Marker marker = new Marker();
                        marker.MarkerId = (string)row[0];
                        marker.DocId = (string)row[1];
                        marker.UserID = (string)row[2];
                        marker.MarkerType = (string)row[3];
                        marker.CenterX = (decimal)row[4];
                        marker.CenterY = (decimal)row[5];
                        marker.RadiusX = (decimal)row[6];
                        marker.RadiusY = (decimal)row[7];
                        marker.ForeColor = (string)row[8];
                        marker.BackColor = (string)row[9];
                        retval.Markers.Add(marker);
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
