using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLContext
    {

        private DALContext _dalContext = new DALContext();
        private DiagnosisBL _diagnosis;
        private MedicalPersonnelBL _medicalPersonnel;
        private MedicalTestBL _medicalTest;
        private PatientBL _patient;
        private SpecializationBL _specialization;
        private AppointmentBL _appointment;
        private UserBL _user;

        public DiagnosisBL Diagnosis
        {
            get
            {
                if(_diagnosis == null)
                {
                    _diagnosis = new DiagnosisBL(_dalContext.DiagnosisDAL);
                }
                return _diagnosis;
            }
        }

        public MedicalPersonnelBL MedicalPersonnel
        {
            get
            {
                if(_medicalPersonnel == null)
                {
                    _medicalPersonnel = new MedicalPersonnelBL(_dalContext.MedicalPersonnelDAL);
                }
                return _medicalPersonnel;
            }
        }

        public MedicalTestBL MedicalTest
        {
            get
            {
                if(_medicalTest == null)
                {
                    _medicalTest = new MedicalTestBL(_dalContext.MedicalTestDAL);
                }
                return _medicalTest;
            }
        }

        public PatientBL Patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new PatientBL(_dalContext.PatientDAL);
                }
                return _patient;
            }
        }

        public SpecializationBL Specialization
        {
            get
            {
                if (_specialization == null)
                {
                    _specialization = new SpecializationBL(_dalContext.SpecializationDAL);
                }
                return _specialization;
            }
        }

        public AppointmentBL Appointment
        {
            get
            {
                if (_appointment == null)
                {
                    _appointment = new AppointmentBL(_dalContext.AppointmentDAL);
                }
                return _appointment;
            }
        }

        public UserBL User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserBL(_dalContext.UserDAL);
                }
                return _user;
            }
        }
    }
}
