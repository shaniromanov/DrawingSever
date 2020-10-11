using Contracts.DTO;
using DrawingContracts.DTO;

namespace DrawingContracts.Interface
{
   public interface IRemoveDocumentService
    {
        Response RemoveDocument(RemoveDocumentRequest request);
    }
}
