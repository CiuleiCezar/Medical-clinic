using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataAccessLayer;

namespace BusinessLayer
{
    public class MedicalPersonnelBL 
    {

        private MedicalPersonnelDAL _medicalPersonnelDAL;

        public MedicalPersonnelBL(MedicalPersonnelDAL medicalPersonnelDAL)
        {
            _medicalPersonnelDAL = medicalPersonnelDAL;
        }

        public void DeleteById(Guid id)
        {
            _medicalPersonnelDAL.DeleteById(id);
        }

        public void Insert(MedicalPersonnel medicalPersonnel)
        {
            _medicalPersonnelDAL.Insert(medicalPersonnel);
        }

        public MedicalPersonnel ReadById(Guid id)
        {
            return _medicalPersonnelDAL.ReadById(id);
        }

        public void UpdateMedicalPersonnelSalary(Guid id, int salary)
        {
            _medicalPersonnelDAL.UpdateSalary(id, salary);
        }
    }
}
