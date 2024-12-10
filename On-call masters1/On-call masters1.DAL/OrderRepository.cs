using Npgsql;
using On_call_masters1.Core.Models;
using On_call_masters1.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace On_call_masters1.DAL
{
    public class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddOrder(Order order)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "INSERT INTO \"Order\" (\"PriceOfOrder\", \"UserID\", \"WorkRegionID\") VALUES (@PriceOfOrder, @UserID, @WorkRegionID)";
                db.Execute(sql, order);
            }
        }

        public Order GetOrderById(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM \"Order\" WHERE "id" = @Id";
                return db.QuerySingleOrDefault<Order>(sql, new { Id = id });
            }
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM \"Order\" WHERE \"UserID\" = @UserID";
                return db.Query<Order>(sql, new { UserID = userId });
            }
        }
    }
}


