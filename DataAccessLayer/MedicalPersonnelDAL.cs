using Model;
using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class MedicalPersonnelDAL
    {

        private string _connectionString;
        private const string MEDICAL_PERSONNEL_READ_BY_ID = "dbo.MedicalPersonnel_ReadById";
        private const string MEDICAL_PERSONNEL_DELETE_BY_ID = "dbo.MedicalPersonnel_DeleteBy_Id";
        private const string MEDICAL_PERSONNEL_UPDATE_SALARY_BY_ID = "dbo.MedicalPersonnel_Update_Salary_By_Id";
        private const string MEDICAL_PERSONNEL_INSERT = "dbo.MedicalPersonnel_Insert";

        public MedicalPersonnelDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MedicalPersonnel ReadById(Guid id)
        {
            MedicalPersonnel medicalPersonnel = new MedicalPersonnel();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = MEDICAL_PERSONNEL_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", id));
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

        public void DeleteById(Guid ID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = MEDICAL_PERSONNEL_DELETE_BY_ID;
                    command.Parameters.Add(new SqlParameter("@Id", ID));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSalary(Guid id, int salary)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = MEDICAL_PERSONNEL_UPDATE_SALARY_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", id));
                    command.Parameters.Add(new SqlParameter("@Salary", salary));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(MedicalPersonnel medicalPersonnel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {                    
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = MEDICAL_PERSONNEL_INSERT;
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@FirstName", medicalPersonnel.firstName),
                        new SqlParameter("@LastName", medicalPersonnel.lastName),
                        new SqlParameter("@EmailAddress", medicalPersonnel.emailAddress),
                        new SqlParameter("@PhoneNumber", medicalPersonnel.phoneNumber),
                        new SqlParameter("@Type", medicalPersonnel.type),
                        new SqlParameter("@Information", medicalPersonnel.information),
                        new SqlParameter("@Room", medicalPersonnel.room),
                        new SqlParameter("@Salary", medicalPersonnel.salary),
                        new SqlParameter("@SpecializationID", medicalPersonnel.specializationID)
                    };
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }

        public MedicalPersonnel ConvertToModel(SqlDataReader dataReader)
        {
            MedicalPersonnel medicalPersonnel = new MedicalPersonnel();

            medicalPersonnel.id = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            medicalPersonnel.firstName= dataReader.GetString(dataReader.GetOrdinal("FirstName"));
            medicalPersonnel.lastName = dataReader.GetString(dataReader.GetOrdinal("LastName"));
            medicalPersonnel.emailAddress = dataReader.GetString(dataReader.GetOrdinal("EmailAddress"));
            medicalPersonnel.type = dataReader.GetString(dataReader.GetOrdinal("Type"));
            medicalPersonnel.phoneNumber= dataReader.GetString(dataReader.GetOrdinal("PhoneNumber"));
            medicalPersonnel.information = dataReader.GetString(dataReader.GetOrdinal("Information"));
            medicalPersonnel.room = dataReader.GetString(dataReader.GetOrdinal("Room"));
            medicalPersonnel.salary = dataReader.GetInt32(dataReader.GetOrdinal("Salary"));
            medicalPersonnel.specializationID = dataReader.GetGuid(dataReader.GetOrdinal("SpecializationID"));

            return medicalPersonnel;
        }
    }
}
