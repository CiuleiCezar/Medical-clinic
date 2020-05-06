using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    public class PatientDAL
    {
        private string _connectionString;
        private const string PATIENT_READ_BY_ID = "[dbo].[Patient_ReadById]";
        private const string PATIENT_DELETE_BY_ID = "[dbo].[Patient_DeleteById]";
        private const string PATIENT_UPDATE_DATE = "[dbo].[Patient_Insert]";
        private const string PATIENT_INSERT = "[dbo].[Patient_Insert]";
        private const string PATIENT_SELECT_ALL = "[dbo].[Read_AllPatients]";

        public PatientDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DeleteById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = PATIENT_DELETE_BY_ID;
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(Patient patient)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = PATIENT_INSERT;
                    SqlParameter[] parameters = 
                    {
                        new SqlParameter("@FirstName", patient.firstName),
                        new SqlParameter("@LastName", patient.lastName),
                        new SqlParameter("@Age", patient.age),
                        new SqlParameter("@Gender", patient.gender),
                        new SqlParameter("@BirthDate", patient.birthDate),
                        new SqlParameter("@EmailAddress", patient.emailAddress),
                        new SqlParameter("@PhoneNumber", patient.phoneNumber),
                        new SqlParameter("@Information", patient.informations)
                    };
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Patient ReadById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = PATIENT_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("ID", id));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Patient patient = ConvertToModel(dataReader);
                            return patient;
                        }
                    }
                }
            }

            return null;
        }

        public void UpdateInformationsById(Guid id, String informations)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = PATIENT_UPDATE_DATE;
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("Id", id),
                        new SqlParameter("Informations", informations)
                    };
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Patient> ReadAll()
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = PATIENT_SELECT_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Patient patient = new Patient();
                            patient = ConvertToModel(dataReader);
                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public Patient ConvertToModel(SqlDataReader dataReader)
        {
            Patient patient = new Patient();

            patient.id = dataReader.GetGuid(dataReader.GetOrdinal("Id"));
            patient.firstName = dataReader.GetString(dataReader.GetOrdinal("FirstName"));
            patient.lastName = dataReader.GetString(dataReader.GetOrdinal("LastName"));
            patient.age = dataReader.GetInt32(dataReader.GetOrdinal("Age"));
            patient.gender = dataReader.GetString(dataReader.GetOrdinal("Gender"));
            patient.birthDate = dataReader.GetString(dataReader.GetOrdinal("BirthDate"));
            patient.emailAddress = dataReader.GetString(dataReader.GetOrdinal("EmailAddress"));
            patient.phoneNumber = dataReader.GetString(dataReader.GetOrdinal("PhoneNumber"));
            patient.informations = dataReader.GetString(dataReader.GetOrdinal("Informations"));

            return patient;
        }

       
    }
}
