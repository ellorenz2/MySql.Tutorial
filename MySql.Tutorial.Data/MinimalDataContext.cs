using MySql.Tutorial.Interface;
using MySql.Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySql.Tutorial.Data
{
    public class MinimalDataContext : IMySqlTutorialDataContext
    {

        private readonly string _connectionString;

        public MinimalDataContext()
        {

        }

        public MinimalDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public void Delete(UserDataModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            MySqlConnection connection = new MySqlConnection(this._connectionString);
            connection.Open();

            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = $"delete from user_data";
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }

        public UserDataModel GetUserData(UserDataModel model)
        {
            throw new NotImplementedException();
        }

        public List<UserDataModel> GetUserData()
        {
            List<UserDataModel> userDataModels = new List<UserDataModel>();

            MySqlConnection connection = new MySqlConnection(this._connectionString);
            connection.Open();


            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = $"select id, name, insert_datetime, value from user_data ";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var userDataModel = new UserDataModel();
                        userDataModel.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        userDataModel.Name = reader.GetString(1);
                        userDataModel.InsertDatetime = reader.GetDateTime("insert_datetime");
                        userDataModel.Value = reader.GetDouble("value");
                        userDataModels.Add(userDataModel);
                    }

                }

                return userDataModels;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

                
            }
        }

        public void Insert(UserDataModel model)
        {
            MySqlConnection connection = new MySqlConnection(this._connectionString);
            connection.Open();

            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into user_data (id, name, insert_datetime, value) values ({model.Id},'{model.Name}','{model.InsertDatetime.ToString("yyyy-MM-dd H:mm:ss")}',{model.Value.ToString()})";
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }

        public void Update(UserDataModel model)
        {
            MySqlConnection connection = new MySqlConnection(this._connectionString);
            connection.Open();

            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = $"update user_data set name = ?name, insert_datetime = ?insert_date_time, value= ?value where id = ?id  ";
                    command.Parameters.AddWithValue("?id",model.Id);
                    command.Parameters.AddWithValue("?name", model.Name);
                    command.Parameters.AddWithValue("?insert_date_time", model.InsertDatetime);
                    command.Parameters.AddWithValue("?value", model.Value);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }
        }
    }
}
