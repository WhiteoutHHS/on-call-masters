using Npgsql;
using On_call_masters1.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace On_call_masters1.DAL
{
    public class WorkRegionRepository
    {
        private readonly string _connectionString;

        public WorkRegionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddWorkRegion(WorkRegion workRegion)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "INSERT INTO \"WorkRegion\" (\"Name\") VALUES (@Name)";
                db.Execute(sql, workRegion);
            }
        }

        public IEnumerable<WorkRegion> GetAllWorkRegions()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM \"WorkRegion\"";
                return db.Query<WorkRegion>(sql);
            }
        }
    }
}
