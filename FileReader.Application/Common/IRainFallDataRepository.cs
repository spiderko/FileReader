using System.Data;

namespace FileReader.Application.Common
{
    public interface IRainFallDataRepository
    {
        void Insert(DataTable dataTable);
    }
}