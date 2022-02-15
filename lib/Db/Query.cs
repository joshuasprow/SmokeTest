using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Db
{
    class Query
    {
        public static async Task GetLocations(SqlConnection conn)
        {
            var stmt = "execute usp_Location_FindAll;";

            Console.WriteLine($"statement: `{stmt}`");

            var cmd = new SqlCommand(stmt, conn);

            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                var rows = 0;

                while (await reader.ReadAsync())
                {
                    if (rows > 10)
                    {
                        return;
                    }

                    var location = new Location(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDecimal(3),
                        reader.GetInt32(4),
                        reader.GetString(5)
                    );

                    Console.WriteLine($"  {location}");

                    rows++;
                }
            }

            Console.WriteLine();
        }

        public static async Task GetUserStatus(SqlConnection conn)
        {
            var stmt = "select UserStatusId, Display, Description from UserStatus;";

            Console.WriteLine($"statement: `{stmt}`");

            var cmd = new SqlCommand(stmt, conn);

            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var userStatus = new UserStatus(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2)
                    );

                    Console.WriteLine($"  {userStatus}");
                }
            }

            Console.WriteLine();
        }

        public static async Task SmokeTest(SqlConnection conn)
        {
            Console.WriteLine("checking connection:");

            var cmd = new SqlCommand("select cast(1 + $1 as int) as two;", conn);

            cmd.Parameters.AddWithValue("one", 1);

            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"1 + 1 = { reader.GetInt32(0)}");
                }
            }

            Console.WriteLine();
        }
    }
}