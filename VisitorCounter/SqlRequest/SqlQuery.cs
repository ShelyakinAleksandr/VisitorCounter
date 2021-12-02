using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data.Common;
using System.Data;

namespace VisitorCounter.SqlRequest
{
    public class SqlQuery
    {
        public AppDb Db { get; }

        public SqlQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<int> CountVisitor(int parametr)
        {
            string sqlQuesry = @"call VisitorCounters(@parametr)";

            MySqlCommand cmd = new MySqlCommand(sqlQuesry, Db.Connection);

            cmd.Parameters.Add(new MySqlParameter { ParameterName = "@parametr", DbType = DbType.Int32, Value = parametr });

            int ansver = 0;

            await Db.Connection.OpenAsync();
            
            DbDataReader reader = cmd.ExecuteReader();
                
            while (reader.Read())
            {
                ansver = reader.GetInt32(0);
            }

            await Db.Connection.CloseAsync();
            return ansver;
        }

        public async Task<DataTable> StatisticVisitor(DateTime DateStart, DateTime? DateEnd)
        {
            DataTable table = new DataTable();

            string sqlQuesry = @"call StatisticVisitor(@DateStart, @DateEnd)";

            MySqlCommand cmd = new MySqlCommand(sqlQuesry, Db.Connection);

            cmd.Parameters.Add(new MySqlParameter { ParameterName = "@DateStart", DbType = DbType.Date, Value = DateStart });
            if(DateEnd != new DateTime(1,1,1,0,0,0))
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@DateEnd", DbType = DbType.Date, Value = DateEnd });
            else
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@DateEnd", DbType = DbType.Date, Value = DBNull.Value });

            await Db.Connection.OpenAsync();

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(table);
            await Db.Connection.CloseAsync();

            return table;
        }
    }
}
