using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicesLayer.Controllers
{
    public class MedicalPersonnelController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpGet]
        public MedicalPersonnel ReadById(Guid id)
        {
            return _blContext.MedicalPersonnel.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.MedicalPersonnel.DeleteById(id);
        }

        [HttpPut]
        public void UpdateSalary(Guid id, int salary)
        {
            _blContext.MedicalPersonnel.UpdateMedicalPersonnelSalary(id, salary);
        }

        [HttpPost]
        public void Insert(MedicalPersonnel medicalPersonnel)
        {
            _blContext.MedicalPersonnel.Insert(medicalPersonnel);
        }
    }
}
