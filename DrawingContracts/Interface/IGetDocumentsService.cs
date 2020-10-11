using Contracts.DTO;
using DrawingContracts.DTO;


namespace DrawingContracts.Interface
{
    public interface IGetDocumentsService
    {
        Response GetDocuments(string request);
    }
}
