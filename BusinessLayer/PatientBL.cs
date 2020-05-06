using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataAccessLayer;

namespace BusinessLayer
{
    public class PatientBL
    {

        private PatientDAL _patientDAL;
        public PatientBL(PatientDAL patientDAL)
        {
            _patientDAL = patientDAL;
        }

        public void DeleteById(Guid id)
        {
            _patientDAL.DeleteById(id);
        }

        public void Insert(Patient patient)
        {
            _patientDAL.Insert(patient);
        }

        public Patient ReadById(Guid id)
        {
            return _patientDAL.ReadById(id);
        }

        public void UpdateInformationsById(Guid id, string informations)
        {
            _patientDAL.UpdateInformationsById(id, informations);
        }

        public List<Patient> ReadAll(){
            return _patientDAL.ReadAll();
        }
    }
}
