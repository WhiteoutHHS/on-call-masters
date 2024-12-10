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
    public class TagRepository
    {
        private readonly string _connectionString;

        public TagRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddTag(Tag tag)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "INSERT INTO \"Tags\" (\"Name\") VALUES (@Name)";
                db.Execute(sql, tag);
            }
        }

        public IEnumerable<Tag> GetAllTags()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM \"Tags\"";
                return db.Query<Tag>(sql);
            }
        }
    }
}
