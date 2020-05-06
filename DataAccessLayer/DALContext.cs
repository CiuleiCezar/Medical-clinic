using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DALContext
    {

        private const string _connectionString = "Server=DESKTOP-986JRQ9;Database=ClinicaMedicala;Trusted_Connection=True;";
        private AppointmentDAL _appointmentDAL;
        private MedicalPersonnelDAL _medicalPersonnelDAL;
        private DiagnosisDAL _diagnosisDAL;
        private PatientDAL _patientDAL;
        private MedicalTestDAL _medicalTestDAL;
        private SpecializationDAL _specializationDAL;
        private UserDAL _userDAL;
        public AppointmentDAL AppointmentDAL
        {
            get
            {
                if(_appointmentDAL == null)
                {
                    _appointmentDAL = new AppointmentDAL(_connectionString);
                }
                return _appointmentDAL;
            }
        }

        public MedicalPersonnelDAL MedicalPersonnelDAL
        {
            get
            {
                if (_medicalPersonnelDAL == null)
                {
                    _medicalPersonnelDAL = new MedicalPersonnelDAL(_connectionString);
                }
                return _medicalPersonnelDAL;
            }
        }

        public DiagnosisDAL DiagnosisDAL
        {
            get
            {
                if (_diagnosisDAL == null)
                {
                    _diagnosisDAL = new DiagnosisDAL(_connectionString);
                }
                return _diagnosisDAL;
            }
        }

        public PatientDAL PatientDAL
        {
            get
            {
                if(_patientDAL == null)
                {
                    _patientDAL = new PatientDAL(_connectionString);
                }
                return _patientDAL;
            }
        }

        public MedicalTestDAL MedicalTestDAL
        {
            get
            {
                if(_medicalTestDAL == null)
                {
                    _medicalTestDAL = new MedicalTestDAL(_connectionString);
                }
                return _medicalTestDAL;
            }
        }

        public SpecializationDAL SpecializationDAL
        {
            get
            {
                if(_specializationDAL == null)
                {
                    _specializationDAL = new SpecializationDAL(_connectionString);
                }
                return _specializationDAL;
            }
        }

        public UserDAL UserDAL
        {
            get
            {
                if(_userDAL == null)
                {
                    _userDAL = new UserDAL(_connectionString);
                }
                return _userDAL;
            }
        }
    }
}
