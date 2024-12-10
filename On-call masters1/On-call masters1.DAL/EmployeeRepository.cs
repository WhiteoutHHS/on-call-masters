using Dapper;
using Npgsql;
using On_call_masters1.Core.Models;
using System.Data;

namespace On_call_masters1.DAL
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddEmployee(Employee employee)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "INSERT INTO \"Employee\" (\"WorkRegionID\") VALUES (@WorkRegionID)";
                db.Execute(sql, employee);
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM \"Employee\" WHERE "id" = @Id";
                return db.QuerySingleOrDefault<Employee>(sql, new { Id = id });
            }
        }

        public IEnumerable<Employee> GetEmployeesByWorkRegion(int workRegionId)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM \"Employee\" WHERE \"WorkRegionID\" = @WorkRegionID";
                return db.Query<Employee>(sql, new { WorkRegionID = workRegionId });
            }
        }
    }
}
