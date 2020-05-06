using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataAccessLayer;

namespace BusinessLayer
{
    public class UserBL
    {

        private UserDAL _userDAL;

        public UserBL(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public void DeleteById(Guid id)
        {
            _userDAL.DeleteById(id);
        }

        public void Insert(User user)
        {
            _userDAL.Insert(user);
        }

        public User ReadById(Guid id)
        {
            return _userDAL.ReadById(id);
        }

        public void UpdatePasswordById(Guid id, string password)
        {
            _userDAL.UpdatePasswordById(id, password);
        }
    }
}
