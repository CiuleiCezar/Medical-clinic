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
    public class SpecializationController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.Specialization.DeleteById(id);
        }

        [HttpPost]
        public void Insert([FromBody]string specializationName)
        {
            _blContext.Specialization.Insert(specializationName);
        }

        [HttpGet]
        public Specialization ReadById(Guid id)
        {
            return _blContext.Specialization.ReadById(id);
        }
    }
}
