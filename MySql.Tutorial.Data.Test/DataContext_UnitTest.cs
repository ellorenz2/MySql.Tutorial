using MySql.Tutorial.Models;
using System;
using Xunit;

namespace MySql.Tutorial.Data.Test
{
    public class DataContext_UnitTest
    {
        public static string connectionString = "Data Source=localhost;Database=tutorial_db;userid=tutorial_user;password=&UKijjPn5D";

        [Fact]
        public void TestInsertModel()
        {

            MinimalDataContext dataContext = new MinimalDataContext(connectionString);


            UserDataModel dataModel = new UserDataModel();
            dataModel.Id = 1;
            dataModel.Name = "Lorenzo";
            dataModel.InsertDatetime = DateTime.Now;
            dataModel.Value = 100;

            dataContext.Insert(dataModel);

            Assert.True(true);

        }

        [Fact]
        public void TestUpdateModel() {

            MinimalDataContext dataContext = new MinimalDataContext(connectionString);


            UserDataModel dataModel = new UserDataModel();
            dataModel.Id = 1;
            dataModel.Name = "Marco";
            dataModel.InsertDatetime = DateTime.Now;
            dataModel.Value = 200;

            dataContext.Update(dataModel);

            Assert.True(true);

        }
    }
}
