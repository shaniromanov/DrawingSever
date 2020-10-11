using Contracts.DTO;
using DrawingContracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrawingContracts.Interface
{
    public interface IOnDocumentSharing
    {
        Response DocumentSharing(DocumentSharingRequest request);
        Response StopDocumentSharing(DocumentSharingRequest request);
        Response GetReciversOfDocument(GetReciversOfDocumentRequest request);
    }
}
