using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Diagnosis
    {

        public Guid ID;
        public Guid patientID;
        public Guid medicalPersonnelID;
        public string description;
        public string treatment;
        public string remarks;

        public void SetDiagnosisId(Guid diagnosisID)
        {
            this.ID = diagnosisID;
        }

        public Guid GetDiagnosisId()
        {
            return this.ID;
        }

        public void SetMedicalPersonnelID()
        {
            medicalPersonnelID = Guid.NewGuid();
        }

        public Guid GetMedicalPersonnelID()
        {
            return medicalPersonnelID;
        }

        public void SetPatientId(Guid patientID)
        {
            this.patientID = patientID;
        }

        public Guid GetPatientId()
        {
            return this.patientID;
        }

        public Diagnosis(Guid diagnosisID, Guid patientID, Guid medicalPersonnelID, string description, string treatment, string remarks)
        {
            this.ID = diagnosisID;
            this.patientID = patientID;
            this.medicalPersonnelID = medicalPersonnelID;
            this.description = description;
            this.treatment = treatment;
            this.remarks = remarks;
        }

        public Diagnosis()
        {

        }
    }
}
