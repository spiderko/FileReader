using FileReader.Application.Common;
using System.Data;
using System.Data.SqlClient;

namespace FileReader.Infrastructure.Repositories
{
    public class RainFallDataRepository : IRainFallDataRepository
    {
        public void Insert(DataTable dataTable)
        {
            var connection = new SqlConnection("Server=localhost;Database=RainFallData;Trusted_Connection=True;");
            var tableName = "RainFall";

            BulkCopy(connection, tableName, dataTable);
        }

        private void BulkCopy(SqlConnection sqlConnection, string tableName, DataTable dataTable)
        {
            using (var bulkCopy = new SqlBulkCopy(sqlConnection))
            {
                sqlConnection.Open();
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BatchSize = 50000;
                bulkCopy.BulkCopyTimeout = 60;

                bulkCopy.WriteToServer(dataTable);
                sqlConnection.Close();
            }
        }
    }
}
