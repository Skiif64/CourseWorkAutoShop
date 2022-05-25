using System.IO;

namespace Shop.Data
{
    public class ConnectionStringLoader
    {
        private static string _dbAdress = string.Empty;
        private const string PATH = @"ConnectionString.txt";

        public static string GetDBAdress()
        {
            if (_dbAdress == string.Empty)
            {
                if (!File.Exists(PATH)) File.AppendAllText(PATH, @"localhost\SQLEXPRESS");
                var lines = File.ReadAllLines(PATH);
                _dbAdress = lines[0];
            }
            return $@"Server={_dbAdress};Database=Crm;Trusted_Connection=True;";
        }
    }
}