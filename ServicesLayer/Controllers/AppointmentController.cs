using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicesLayer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AppointmentController : ApiController
    {
        private BLContext _bLContext = new BLContext();

        [HttpGet]
        public Appointment ReadById(Guid id)
        {
            return _bLContext.Appointment.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById([FromBody]Guid id)
        {
            _bLContext.Appointment.DeleteById(id);
        }

        [HttpPost]
        public void Insert([FromBody]Appointment appointment)
        {
            _bLContext.Appointment.InsertAppointment(appointment);
        }

        [HttpPut]
        public void UpdateAppointmentDateById(Guid appointmentID, DateTime date)
        {
            _bLContext.Appointment.UpdateDateById(appointmentID, date);
        }
    }
}
