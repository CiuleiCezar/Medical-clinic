using System;
using Model;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class AppointmentDAL
    {
        private string _connectionString;
        private const string APPOINTMENT_READ_BY_GUID = "dbo.Appointment_ReadById";
        private const string APPOINTMENT_DELETE_BY_ID = "dbo.Appointment_DeleteById";
        private const string APPOINTMENT_UPDATE_DATE = "dbo.Appointment_Update_Date";
        private const string APPOINTMENT_INSERT = "dbo.Appointment_Insert";

        public AppointmentDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Appointment ReadById(Guid appointmentID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = APPOINTMENT_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", appointmentID));
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
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = APPOINTMENT_DELETE_BY_ID;
                    command.Parameters.Add(new SqlParameter("@Id", ID));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDateById(Guid appointmentID, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = APPOINTMENT_UPDATE_DATE;
                    command.Parameters.Add(new SqlParameter("@AppointmentID", appointmentID));
                    command.Parameters.Add(new SqlParameter("@Date", date.ToShortDateString()));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertAppointment(Appointment appointment)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = APPOINTMENT_INSERT;
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@MedicalPersonnelID", appointment.medicalPersonnelID),
                        new SqlParameter("@PatientID", appointment.patientID),
                        new SqlParameter("@Date", appointment.date),
                        new SqlParameter("@StartTime", appointment.startTime),
                        new SqlParameter("@EndTime", appointment.endTime),
                        new SqlParameter("@Information", appointment.medicalPersonnelID),
                        new SqlParameter("@Price", appointment.price)
                    };    
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Appointment ConvertToModel(SqlDataReader dataReader)
        {
            Appointment appointment = new Appointment();

            appointment.id = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            appointment.medicalPersonnelID = dataReader.GetGuid(dataReader.GetOrdinal("MedicalPersonnelID"));
            appointment.patientID = dataReader.GetGuid(dataReader.GetOrdinal("PatientID"));
            appointment.date = dataReader.GetDateTime(dataReader.GetOrdinal("Date"));
            appointment.startTime = dataReader.GetTimeSpan(dataReader.GetOrdinal("StartTime"));
            appointment.endTime = dataReader.GetTimeSpan(dataReader.GetOrdinal("EndTime"));
            appointment.information = dataReader.GetString(dataReader.GetOrdinal("Information"));
            appointment.price = dataReader.GetInt32(dataReader.GetOrdinal("Price"));

            return appointment;
        }
    }
}
