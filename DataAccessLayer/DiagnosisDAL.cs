using System;
using Model;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DiagnosisDAL
    {

        private string _connectionString;
        private const string DIAGNOSIS_READ_BY_GUID = "dbo.Diagnosis_ReadById";
        private const string DIAGNOSIS_READ_ALL = "dbo.Diagnsosis_SelectAll";
        private const string DIAGNOSIS_DELETE_BY_GUID = "dbo.Diagnosis_DeleteById";
        private const string DIAGNOSIS_INSERT = "dbo.Insert_Diagnosis";

        public DiagnosisDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Diagnosis ReadById(Guid diagnosisId)
        {
            Diagnosis diagnosis = new Diagnosis();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = DIAGNOSIS_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@DiagnosisID", diagnosisId));
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

        public List<Diagnosis> ReadAll()
        {
            List<Diagnosis> diagnoses = new List<Diagnosis>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();  
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = DIAGNOSIS_READ_ALL;
                    using(SqlDataReader dataReader = command.ExecuteReader()) 
                    {
                        while (dataReader.Read())
                        {
                            Diagnosis diagnosis = ConvertToModel(dataReader);
                            diagnoses.Add(diagnosis);
                        }
                    }
                }
            }

            return diagnoses;
        }

        public void DeleteById(Guid diagnosisID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = DIAGNOSIS_DELETE_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", diagnosisID));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(Diagnosis diagnosis)
        {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = DIAGNOSIS_INSERT;
                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@MedicalPersonnelID", diagnosis.medicalPersonnelID),
                            new SqlParameter("@PatientID", diagnosis.patientID),
                            new SqlParameter("@Description", diagnosis.description),
                            new SqlParameter("@Treatment", diagnosis.treatment),
                            new SqlParameter("@Remarks", diagnosis.remarks)
                        };
                        command.Parameters.AddRange(parameters);
                        command.ExecuteNonQuery();
                    }
                }
        }    

        public Diagnosis ConvertToModel(SqlDataReader dataReader)
        {
            Diagnosis diagnosis = new Diagnosis();

            diagnosis.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            diagnosis.medicalPersonnelID = dataReader.GetGuid(dataReader.GetOrdinal("MedicalPersonnelID"));
            diagnosis.patientID = dataReader.GetGuid(dataReader.GetOrdinal("PatientID"));
            diagnosis.description = dataReader.GetString(dataReader.GetOrdinal("Description"));
            diagnosis.treatment = dataReader.GetString(dataReader.GetOrdinal("Treatment"));
            diagnosis.remarks = dataReader.GetString(dataReader.GetOrdinal("Remarks"));

            return diagnosis;
        }
    }
}


