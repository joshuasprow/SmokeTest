// using Npgsql;
// using System;
// using System.IO;
// using System.Text.Json;
// using System.Threading.Tasks;

// namespace Postgres
// {
//     class Config
//     {
//         public string Host { get; set; } = "localhost";
//         public int Port { get; set; } = 5432;
//         public string Username { get; set; } = "postgres";
//         public string Password { get; set; } = "mysecretpassword";
//         public string Database { get; set; } = "warehouse";

//         public string ConnString()
//         {
//             var cs = new NpgsqlConnectionStringBuilder();

//             cs.Host = Host;
//             cs.Port = Port;
//             cs.Username = Username;
//             cs.Password = Password;
//             cs.Database = Database;
//             cs.SslMode = SslMode.Disable;

//             return cs.ToString();
//         }
//     }

//     class Postgres
//     {
//         public Config LoadConfig()
//         {
//             try
//             {
//                 var file = "config.json";
//                 var json = File.ReadAllText(file);

//                 return JsonSerializer.Deserialize<Config>(json);
//             }
//             catch (System.IO.FileNotFoundException)
//             {
//                 Console.WriteLine("config.json not found; using defaults");

//                 return new Config();
//             }
//         }

//         public async Task RunSmokeTest(string connString)
//         {
//             await using var conn = new NpgsqlConnection(connString);
//             await conn.OpenAsync();

//             var cmd = new NpgsqlCommand("select 1 + $1;", conn);
//             cmd.Parameters.AddWithValue(1);

//             await using (var reader = await cmd.ExecuteReaderAsync())
//             {
//                 while (await reader.ReadAsync())
//                 {
//                     Console.WriteLine("1 + 1 = {0}", reader.GetInt32(0));
//                 }
//             }
//         }
//     }
// }
