using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Db
{
    class Conn
    {
        public static async Task<SqlConnection> Open(Config config)
        {
            var conn = new SqlConnection(config.ConnString());

            await conn.OpenAsync();

            return conn;
        }

        public async Task SmokeTest(SqlConnection conn)
        {
            var cmd = new SqlCommand("select cast(1 + $1 as int) as two;", conn);
            cmd.Parameters.AddWithValue("one", 1);

            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine("1 + 1 = {0}", reader.GetInt32(0));
                }
            }
        }
    }
}