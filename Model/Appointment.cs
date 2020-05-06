using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Appointment
    {
        public Guid id;
        public Guid medicalPersonnelID;
        public Guid patientID;
        public DateTime date;
        public TimeSpan startTime;
        public TimeSpan endTime;
        public string information;
        public int price;

        public Appointment(Guid medicalPersonnelID, Guid patientID, DateTime date, TimeSpan startTime,
            TimeSpan endTime, string information, int price)
        {
            this.id = new Guid();
            this.medicalPersonnelID = medicalPersonnelID;
            this.patientID = patientID;
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.information = information;
            this.price = price;
        }

        public Appointment()
        {

        }
    }
}
