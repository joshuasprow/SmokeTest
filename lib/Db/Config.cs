using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;

namespace Db
{
    class Config
    {

        public string DataSource { get; set; } = "localhost";
        public string InitialCatalog { get; set; } = "master";
        public bool IntegratedSecurity { get; set; } = false;
        public string UserID { get; set; } = "sa";
        public string Password { get; set; } = "My$eCretPazzW0rd";

        public string ConnString()
        {
            var cs = new SqlConnectionStringBuilder();


            cs.DataSource = DataSource;
            cs.InitialCatalog = InitialCatalog;
            cs.IntegratedSecurity = IntegratedSecurity;
            cs.UserID = UserID;
            cs.Password = Password;

            return cs.ToString();
        }

        public static Config Load(string filename = "config.json")
        {
            try
            {
                var json = File.ReadAllText(filename);

                return JsonSerializer.Deserialize<Config>(json);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("config.json not found; using defaults");

                return new Config();
            }
        }
    }
}
