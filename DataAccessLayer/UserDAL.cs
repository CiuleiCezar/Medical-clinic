using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    public class UserDAL
    {

        private string _connectionString;
        private const string USER_READ_BY_GUID = "[dbo].[User_ReadById]";
        private const string USER_UPDATE_PASSWORD = "[dbo].[User_UpdatePassword]";
        private const string USER_DELETE_BY_GUID = "[dbo].[User_DeleteById]";
        private const string USER_INSERT = "[dbo].[User_Insert]";

        public UserDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User ReadById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = USER_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("Id", id));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                           return ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return null;
        }

        public void DeleteById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = USER_DELETE_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = USER_INSERT;
                    SqlParameter[] parameters = {                 
                        new SqlParameter("@MedicalPersonnelId", user.GetMedicalPersonnaleId()),
                        new SqlParameter("Password", user.GetPassword()),
                        new SqlParameter("Username", user.username)
                    };
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdatePasswordById(Guid id, string password)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = USER_UPDATE_PASSWORD;
                    SqlParameter[] paramaters =
                    {
                        new SqlParameter("@Id", id),
                        new SqlParameter("@Passwprd", password)
                    };
                    command.Parameters.AddRange(paramaters);
                    command.ExecuteNonQuery();
                }
            }
        }

        public User ConvertToModel(SqlDataReader dataReader)
        {
            User user = new User();

            user.SetUserId(dataReader.GetGuid(dataReader.GetOrdinal("Id")));
            user.SetMedicalPersonnelId(dataReader.GetGuid(dataReader.GetOrdinal("MedicalPersonnelId")));
            user.SetPassword(dataReader.GetString(dataReader.GetOrdinal("Password")));
            user.username = dataReader.GetString(dataReader.GetOrdinal("Username"));

            return user;
        }
    }
}
