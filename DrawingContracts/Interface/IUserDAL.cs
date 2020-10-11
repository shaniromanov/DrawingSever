using System.Data;

namespace DrawingContracts.Interface
{
    public interface IUserDAL
    {
        DataSet CreateUser(string id, string userName);
        DataSet RemoveUser(string id);

        DataSet GetUser(string id);
    }
}
