using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataAccessLayer;

namespace BusinessLayer
{
    public class DiagnosisBL
    {

        private DiagnosisDAL _diagnosisDAL;

        public DiagnosisBL(DiagnosisDAL diagnosisDAL)
        {
            _diagnosisDAL = diagnosisDAL;
        }

        public void DeleteById(Guid id)
        {
            _diagnosisDAL.DeleteById(id);
        }

        public void Insert(Diagnosis diagnosis)
        {
            _diagnosisDAL.Insert(diagnosis);
        }

        public List<Diagnosis> ReadAll()
        {
            return _diagnosisDAL.ReadAll();
        }

        public Diagnosis ReadById(Guid id)
        {
            return _diagnosisDAL.ReadById(id);
        }
    }
}
