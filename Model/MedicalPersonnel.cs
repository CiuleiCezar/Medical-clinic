using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MedicalPersonnel
    {

        public Guid id;
        public string firstName;
        public string lastName;
        public string emailAddress;
        public string phoneNumber;
        public string type;
        public Guid specializationID;
        public string information;
        public string room;
        public int salary;
        public MedicalPersonnel()
        {

        }
        
        public MedicalPersonnel(Guid medicalPersonnelID, string firstName, string lastName, string emailAddress, string phoneNumber,
            string type, Guid specializationID, string information, string room, int salary)
        {
            this.id = new Guid();
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.type = type;
            this.specializationID = specializationID;
            this.information = information;
            this.room = room;
            this.salary = salary;

        }
    }
}
