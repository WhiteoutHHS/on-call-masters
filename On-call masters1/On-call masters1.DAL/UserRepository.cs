using Dapper;
using Npgsql;
using On_call_masters1.Core;
using ProjectName.Core.Models;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddUser(User user)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionString))
        {
            string sql = "INSERT INTO \"User\" (\"name\", \"password\", \"RolesID\") VALUES (@Name, @Password, @RolesID)";
            db.Execute(sql, user);
        }
    }

    public User GetUserById(int id)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM \"User\" WHERE "id" = @Id";
            return db.QuerySingleOrDefault<User>(sql, new { Id = id });
        }
    }

    public IEnumerable<User> GetAllUsers()
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM \"User\"";
            return db.Query<User>(sql);
        }
    }
}
