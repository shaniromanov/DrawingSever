using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DrawingContracts.Interface
{
    public interface IMarkerDAL
    {
        DataSet CreateMarker(string id, string docId, string userID, string markerType, decimal centerX,
                             decimal centerY, decimal radiusX, decimal radiusY, string foreColor, string backColor);
        DataSet GetMarkers(string DocId);
        DataSet RemoveMarker(string markerId);
        DataSet UpdateBackColorMarker(string markerId, string color);
        DataSet UpdateForeColorMarker(string markerId, string color);
    }
}
