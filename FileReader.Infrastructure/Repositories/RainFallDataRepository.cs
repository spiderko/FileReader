using FileReader.Core.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileReader.Infrastructure.Repositories
{
    public class RainFallDataRepository
    {
        public void Insert(IEnumerable<RainFallData> data)
        {
            var connection = new SqlConnection("Server=localDb;Database=RainFallData;Trusted_Connection=True;");
            var tableName = "RainFall";
            var dataTable = new DataTable();

            BulkCopy(connection, tableName, dataTable);
        }

        private void BulkCopy(SqlConnection sqlConnection, string tableName, DataTable dataTable)
        {
            using (var bulkCopy = new SqlBulkCopy(sqlConnection))
            {
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BatchSize = 50000;
                bulkCopy.BulkCopyTimeout = 60;

                bulkCopy.WriteToServer(dataTable);
            }
        }
    }
}
