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
    public class UserController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpGet]
        public User ReadById(Guid id)
        {
            return _blContext.User.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.User.DeleteById(id);
        }

        [HttpPost]
        public void Insert([FromBody]User user)
        {
            _blContext.User.Insert(user);
        }

        [HttpPut]
        public void UpdatePasswordById(Guid id, string password)
        {
            _blContext.User.UpdatePasswordById(id, password);
        }
    }
}
