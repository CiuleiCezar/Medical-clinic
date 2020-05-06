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
    public class MedicalTestController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpGet]
        public MedicalTest ReadById(Guid id)
        {
            return _blContext.MedicalTest.ReadById(id);
        }

        [HttpPut]
        public void UpdateResultById(Guid id, string result)
        {
            _blContext.MedicalTest.UpdateResultById(id, result);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.MedicalTest.DeleteById(id);
        }

        [HttpPost]
        public void Insert(MedicalTest medicalTest)
        {
            _blContext.MedicalTest.Insert(medicalTest);
        }
    }
}
