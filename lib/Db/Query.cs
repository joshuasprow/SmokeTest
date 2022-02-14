using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Db
{
    class UserStatus
    {
        public UserStatus(int userStatusId, string display, string description)
        {
            UserStatusId = userStatusId;
            Display = display;
            Description = description;
        }

        public int UserStatusId { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }


        override public string ToString()
        {
            return $"[{UserStatusId}] {Display} | {Description}";
        }
    }

    class Query
    {
        public static async Task GetUserStatus(SqlConnection conn)
        {
            var cmd = new SqlCommand("select UserStatusId, Display, Description from UserStatus;", conn);

            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var us = new UserStatus(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2)
                    );

                    Console.WriteLine(us);
                }
            }
        }

        public static async Task SmokeTest(SqlConnection conn)
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