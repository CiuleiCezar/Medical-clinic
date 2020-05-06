using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MedicalTest
    {

        public Guid id;
        public Guid patientID;
        public string results;
        public DateTime date;

        public void SetMedicalTestId(Guid medicalTestID)
        {
            this.id = medicalTestID;
        }

        public Guid GetMedicalTestId()
        {
            return this.id;
        }

        public void SetPatientId(Guid patientID)
        {
            this.patientID = patientID;
        }

        public Guid GetPatientId()
        {
            return this.patientID;
        }

        public MedicalTest(Guid medicalTestID, Guid patientID, string results, DateTime date)
        {
            this.id = medicalTestID;
            this.patientID = patientID;
            this.results = results;
            this.date = date;
        }

        public MedicalTest()
        {

        }

    }
}
