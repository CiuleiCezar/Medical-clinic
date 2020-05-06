using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    public class SpecializationDAL 
    {
        private string _connectionString;
        private const string SPECIALIZATION_READ_BY_ID = "[dbo].[Specialization_ReadById]";
        private const string SPECIALIZATION_DELETE_BY_ID = "[dbo].[Specialization_DeleteById]";
        private const string SPECIALIZATION_INSERT = "[dbo].[Specialization_Insert]";
        
        public SpecializationDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DeleteById(Guid id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = SPECIALIZATION_DELETE_BY_ID;
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(string specializationName)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = SPECIALIZATION_INSERT;
                    command.Parameters.Add(new SqlParameter("@SpecializationName", specializationName));
                    command.ExecuteNonQuery();
                }
            }
        }

        public Specialization ReadById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = SPECIALIZATION_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@Id", id));
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

        public Specialization ConvertToModel(SqlDataReader dataReader)
        {
            Specialization specialization = new Specialization();

            specialization.id = dataReader.GetGuid(dataReader.GetOrdinal("Id"));
            specialization.specializationName = dataReader.GetString(dataReader.GetOrdinal("SpecializationName"));

            return specialization;
        }
    }
}
