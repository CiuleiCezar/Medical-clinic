using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Patient
    {
        public Guid id;
        public string firstName;
        public string lastName;
        public int age;
        public string gender;
        public string birthDate;
        public string emailAddress;
        public string phoneNumber;
        public string informations;

        public void SetPatientId(Guid patientID)
        {
            this.id = patientID;
        }

        public Guid GetPatientId()
        {
            return this.id;
        }

        public Patient(Guid patientID, string firstName, string lastName, int age, string gender,
      string birthDate, string emailAddress, string phoneNumber, string informations)
        {
            this.id = patientID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
            this.birthDate = birthDate;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.informations = informations;
        }

        public Patient()
        {

        }

    }
}
