using Db;
using System;
using System.Threading.Tasks;

namespace SmokeTest
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            try
            {

                var config = Config.Load();
                var conn = await Conn.Open(config);

                await Query.SmokeTest(conn);
                await Query.GetUserStatus(conn);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
