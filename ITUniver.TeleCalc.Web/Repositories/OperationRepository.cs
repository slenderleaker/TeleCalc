using System.Data.SqlClient;
using ITUniver.TeleCalc.Web.Models;
using System.Linq;

namespace ITUniver.TeleCalc.Web.Repositories
{
    public class OperationRepository : BaseRepository<OperationModel>
    {
        public OperationRepository(string connectionString)
            : base(connectionString)
        {
        }

        internal override string GetSelectQuery()
        {
            return @"SELECT Id, Name, Owner FROM dbo.Operation";
        }

        internal override string GetInsertQuery()
        {
            return @"INSERT INTO dbo.Operation (Name, Owner) VALUES (@name, @owner)";
        }

        public OperationModel LoadByName(string name)
        {
            var opers = Find($"[Name] = N'{name}'");

            return opers.FirstOrDefault();
        }

   }
} 