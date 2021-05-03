using MySql.Tutorial.Models;
using System;
using System.Text;

namespace MySql.Tutorial.Serialization
{
    public class CSVSerializer
    {
        private string _separator = ";";
        public CSVSerializer()
        {

        }

        public CSVSerializer(string separtor)
        {
            _separator = separtor;
        }

        public string Serialize(UserDataModel model) {

            StringBuilder sb = new StringBuilder();
            sb.Append(Convert.ToString(model.Id));
            sb.Append(_separator);
            sb.Append(model.Name);
            sb.Append(_separator);
            sb.Append(model.InsertDatetime.ToString("yyyy-MM-dd H:mm:ss"));
            sb.Append(_separator);
            sb.Append(Convert.ToString(model.Value));

            return sb.ToString();

        }


        public UserDataModel Deserialize(string serialized) {

            UserDataModel model = new UserDataModel();

            var arr = serialized.Split(_separator);
            model.Id = Convert.ToInt32(arr[0]);
            model.Name = arr[1];
            DateTime parsed = new DateTime();
            DateTime.TryParse(arr[2], out parsed);
            model.InsertDatetime = parsed;
            model.Value = Convert.ToDouble(arr[3]);

            return model;
        }


    }
}
