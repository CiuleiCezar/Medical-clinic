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
    public class DiagnosisController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpGet]
        public Diagnosis ReadById(Guid id)
        {
            return _blContext.Diagnosis.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.Diagnosis.DeleteById(id);
        }

        [HttpPost]
        public void Insert(Diagnosis diagnosis)
        {
            _blContext.Diagnosis.Insert(diagnosis);
        }

    }
}
