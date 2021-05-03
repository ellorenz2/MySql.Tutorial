using MySql.Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySql.Tutorial.Interface
{
    public interface IMySqlTutorialDataContext
    {

        void Insert(UserDataModel model);
        void Update(UserDataModel model);

        List<UserDataModel> GetUserData();

        UserDataModel GetUserData(UserDataModel model);

        void Delete(UserDataModel model);

        void DeleteAll();

    }
}
