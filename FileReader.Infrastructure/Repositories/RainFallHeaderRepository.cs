using Dapper;
using FileReader.Application.Common;
using FileReader.Core.Models;
using System.Data.SqlClient;

namespace FileReader.Infrastructure.Repositories
{
    public class RainFallHeaderRepository : IRainFallHeaderRepository
    {
        public void Insert(RainFallHeader data)
        {
            var connection = new SqlConnection("Server=localhost;Database=RainFallData;Trusted_Connection=True;");
            var query = "INSERT INTO [dbo].[RainFallHeader] ([Id],[Title],[Type],[ClimaticResearchUnitVersion],[CreatedBy],[CreatedOn],[LongitudeMin],[LongitudeMax],[LatitudeMin],[LatitudeMax],[GridX],[GridY],[Boxes],[YearMin],[YearMax],[Multi],[Missing],[Created]) VALUES (@Id,@Title,@Type,@ClimaticResearchUnitVersion,@CreatedBy,@CreatedOn,@LongitudeMin,@LongitudeMax,@LatitudeMin,@LatitudeMax,@GridX,@GridY,@Boxes,@YearMin,@YearMax,@Multi,@Missing,@Created)";

            try
            {
                connection.Execute(query, new
                {
                    data.Id,
                    data.Title,
                    data.Type,
                    data.ClimaticResearchUnitVersion,
                    data.CreatedBy,
                    data.CreatedOn,
                    data.LongitudeMin,
                    data.LongitudeMax,
                    data.LatitudeMin,
                    data.LatitudeMax,
                    data.GridX,
                    data.GridY,
                    data.Boxes,
                    data.YearMin,
                    data.YearMax,
                    data.Multi,
                    data.Missing,
                    data.Created
                });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
