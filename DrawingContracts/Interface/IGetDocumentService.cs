using Contracts.DTO;
using DrawingContracts.DTO;


namespace DrawingContracts.Interface
{
   public interface IGetDocumentService
    {
        Response GetDocument(GetDocumentRequest request);
    }
}
