using Microsoft.EntityFrameworkCore;
using MySql.Tutorial.Interface;
using MySql.Tutorial.Models;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace MySql.Tutorial.EntityFramework
{
    public class EntityDataContex : Microsoft.EntityFrameworkCore.DbContext, IMySqlTutorialDataContext
    {

        private string _connectionString = "server=localhost;port=3306;database=EFCoreMySQL;user=root;password=root";

        public EntityDataContex(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ServerVersion.AutoDetect(_connectionString),null);
        }

        public Microsoft.EntityFrameworkCore.DbSet<UserDataModel> UserDataModels { get; set; }


        public void Delete(UserDataModel model)
        {
            UserDataModels.Remove(model);
            this.SaveChanges();
        }

        public void DeleteAll()
        {
            foreach(var model in UserDataModels)
            {
                UserDataModels.Remove(model);
                this.SaveChanges();
            }
        }

        public List<UserDataModel> GetUserData()
        {
            return UserDataModels.ToList();

        }

        public UserDataModel GetUserData(UserDataModel model)
        {
            return UserDataModels.Where(x => x.Id == model.Id).FirstOrDefault();
        }

        public void Insert(UserDataModel model)
        {
            UserDataModels.Add(model);
            this.SaveChanges();
        }

        public void Update(UserDataModel model)
        {
            UserDataModels.Update(model);
        }
    }
}
