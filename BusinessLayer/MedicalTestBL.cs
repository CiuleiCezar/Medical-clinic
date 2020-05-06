using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataAccessLayer;

namespace BusinessLayer
{
    public class MedicalTestBL
    {

        private MedicalTestDAL _medicalTestDAL;

        public MedicalTestBL(MedicalTestDAL medicalTestDAL)
        {
            _medicalTestDAL = medicalTestDAL;
        }

        public void DeleteById(Guid id)
        {
            _medicalTestDAL.DeleteById(id);
        }

        public void Insert(MedicalTest medicalTest)
        {
            _medicalTestDAL.Insert(medicalTest);
        }

        public MedicalTest ReadById(Guid id)
        {
            return _medicalTestDAL.ReadById(id);
        }

        public void UpdateResultById(Guid id, string result)
        {
            _medicalTestDAL.updateResultById(id, result);
        }
    }
}
