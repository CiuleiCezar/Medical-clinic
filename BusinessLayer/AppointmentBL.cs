using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class AppointmentBL
    {

        private AppointmentDAL _apppointmentDAL;

        public AppointmentBL(AppointmentDAL appointmentDAL)
        {
            _apppointmentDAL = appointmentDAL;
        }

        public Appointment ReadById(Guid id)
        {
            return _apppointmentDAL.ReadById(id);
        }

        public void DeleteById(Guid id)
        {
            _apppointmentDAL.DeleteById(id);
        }

        public void UpdateDateById(Guid id, DateTime date)
        {
            _apppointmentDAL.UpdateDateById(id, date);
        }

        public void InsertAppointment(Appointment appointment)
        {
            _apppointmentDAL.InsertAppointment(appointment);
        }
    }
}
