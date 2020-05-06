using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataAccessLayer;

namespace BusinessLayer
{
    public class SpecializationBL
    {
        private SpecializationDAL _specializationDAL;

        public SpecializationBL(SpecializationDAL specializationDAL)
        {
            _specializationDAL = specializationDAL;
        }

        public void DeleteById(Guid id)
        {
            _specializationDAL.DeleteById(id);
        }

        public void Insert(string name)
        {
            _specializationDAL.Insert(name);
        }

        public Specialization ReadById(Guid id)
        {
            return _specializationDAL.ReadById(id);
        }
    }
}
