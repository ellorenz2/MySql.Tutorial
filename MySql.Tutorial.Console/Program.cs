using MySql.Tutorial.Data;
using MySql.Tutorial.Serialization;
using System;
using System.IO;

namespace MySql.Tutorial.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("export.csv")) {

                File.Delete("export.csv");
            
            }
            
            
            string connectionString = "Data Source=localhost;Database=tutorial_db;userid=xxxx;password=xxxxx";

            MinimalDataContext dataContext = new MinimalDataContext(connectionString);
            var mydataList = dataContext.GetUserData();
            CSVSerializer serializer = new CSVSerializer();


            using (StreamWriter file = new StreamWriter("export.csv"))
            {
                foreach (var item in mydataList)
                {
                    file.WriteLine(serializer.Serialize(item));
                }
            }


            dataContext.DeleteAll();


            using (StreamReader reader = new StreamReader("export.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                   var model = serializer.Deserialize(line);
                   dataContext.Insert(model);

                }
            }


        }
    }
}
