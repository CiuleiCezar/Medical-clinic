using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    public class MedicalTestDAL
    {

        private string _connectionString;
        private const string MedicalTest_READ_BY_ID = "[dbo].[MedicalTest_ReadById]";
        private const string MedicalTest_Update_Result = "[dbo].[MedicalTest_UpdateResult]";
        private const string MedicalTest_DELETE_BY_ID = "[dbo].[MedicalTest_DeleteById]";
        private const string MedicalTest_INSERT = "[dbo].[MedicalTest_Insert]";

        public MedicalTestDAL(string coonectionString)
        {
            _connectionString = coonectionString;
        }

        public MedicalTest ReadById(Guid id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand()){
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = MedicalTest_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
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

        public void updateResultById(Guid id, string result)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = MedicalTest_Update_Result;
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Id", id),
                        new SqlParameter("@Results", result)
                    };
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
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
                    command.CommandText = MedicalTest_DELETE_BY_ID;
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(MedicalTest medicalTest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = MedicalTest_INSERT;
                    command.Parameters.Add(new SqlParameter("@PatientId", medicalTest.patientID));
                    command.Parameters.Add(new SqlParameter("@Result", medicalTest.results));
                    command.Parameters.Add(new SqlParameter("@Date", medicalTest.date));
                    command.ExecuteNonQuery();
                }
            }
        }


        public MedicalTest ConvertToModel(SqlDataReader dataReader)
        {
            MedicalTest medicalTest = new MedicalTest();

            medicalTest.id = dataReader.GetGuid(dataReader.GetOrdinal("MedicalTestId"));
            medicalTest.patientID = dataReader.GetGuid(dataReader.GetOrdinal("PatientId"));
            medicalTest.results = dataReader.GetString(dataReader.GetOrdinal("Results"));
            medicalTest.date = dataReader.GetDateTime(dataReader.GetOrdinal("Date"));

            return medicalTest;
        }
    }
}
