using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicesLayer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.Patient.DeleteById(id);
        }

        [HttpPost]
        public void Insert([FromBody]Patient patient)
        {
            _blContext.Patient.Insert(patient);
        }

        [HttpGet]
        public Patient ReadById(Guid id)
        {
            return _blContext.Patient.ReadById(id);
        }

        [HttpGet]
        public List<Patient> ReadAll()
        {
            return _blContext.Patient.ReadAll();
        }

        [HttpGet]
        public String GetShow()
        {
            return "abcdeefg";
        }

        [HttpPut]
        public void UpdateInformationsById(Guid id, String informations)
        {
            _blContext.Patient.UpdateInformationsById(id, informations);
        }
    }
}
