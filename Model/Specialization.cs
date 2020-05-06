using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Specialization
    {
        public Guid id;
        public string specializationName;

        public void setSpecializationID(Guid specializationID)
        {
            specializationID = specializationID;
        }

        public Specialization( string specializationName)
        {
            id = Guid.NewGuid();
            specializationName = specializationName;
        }

        public Specialization()
        {

        }

    }
}
