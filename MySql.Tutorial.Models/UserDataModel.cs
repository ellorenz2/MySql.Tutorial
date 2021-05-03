using System;
using System.Collections.Generic;
using System.Text;

namespace MySql.Tutorial.Models
{
    [Serializable]
    public class UserDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertDatetime { get; set; }
        public double Value { get; set; }


    }
}
