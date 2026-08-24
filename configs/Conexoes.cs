using MySql.Data.MySqlClient;

namespace BlazorApp1.configs
{
    public class Conexoes
    {

        private readonly string _connectionString;
        public Conexoes(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlConnection") ?? "";
        }

        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        public MySqlCommand CreateCommand(string query, MySqlConnection? conn = null)
        {
            conn ??= GetConnection();
            return new MySqlCommand(query, conn);
        }
    }
}
