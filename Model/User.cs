using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class User
    {

        public Guid id;
        public Guid MedicalPersonnelID;
        public string username;
        public string password;

        public void SetUserId(Guid userID)
        {
            this.id = userID;
        }

        public Guid GetUserId()
        {
            return this.id;
        }

        public void SetMedicalPersonnelId(Guid MedicalPersonnelID)
        {
            this.MedicalPersonnelID = MedicalPersonnelID;
        }

        public Guid GetMedicalPersonnaleId()
        {
            return this.MedicalPersonnelID;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public User()
        {

        }

        public User(Guid userID, Guid medicalPersonnelID, string username, string password)
        {
            this.id = userID;
            this.MedicalPersonnelID = medicalPersonnelID;
            this.username = username;
            this.password = password;
        }
    }
}
