using Contracts;
using Contracts.DTO;
using DrawingContracts.DTO;
using DrawingContracts.Interface;
using GenerateIdContracts;
using System;


namespace CreateDocumentService
{
    [Register(Policy.Transient, typeof(ICreateDocumentService))]
    public class CreateDocumentImpl: ICreateDocumentService
    {
        IDocumentDAL _dal;
        IGenerateIdService _idGeneretor;

        public CreateDocumentImpl(IDocumentDAL dal, IGenerateIdService idGeneretor)
        {
            _dal = dal;

            _idGeneretor = idGeneretor;
        }
        public Response CreateDocument(CreateDocumentRequest request)
        {
            try
            {
                var id = _idGeneretor.GenerateId(request.OwnerId + request.DocumentName);
                var ds = _dal.CreateDocument(id, request.OwnerId,request.DocumentName);
                return new CreateDocumentResponseOK(id);
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }
        }
    }
}
