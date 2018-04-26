using ITUniver.TeleCalc.Web.Models;
using System;
using System.Data.SqlClient;

namespace ITUniver.TeleCalc.Web.Repositories
{
    public class HistoryRepository : BaseRepository<HistoryItemModel>
    {
        public HistoryRepository(string connectionString) : base(connectionString)
        {
            
        }

        internal override string GetSelectQuery()
        {
            return @"SELECT Id, Operation, Initiator, Args, Result, CalcDate, Time FROM dbo.History";
        }

        internal override string GetInsertQuery()
        {
            return @"INSERT INTO dbo.History (Operation, Initiator, Args, Result, CalcDate, Time) VALUES (@Operation, @Initiator, @Args, @Result, @CalcDate, @Time)";
        }
    }
}