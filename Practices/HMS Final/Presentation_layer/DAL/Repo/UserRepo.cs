using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo_doctor<UserRepo, string,bool>,IAuth<User>
    {
        HospitalEntities db;

        public UserRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public User Authenticate(string Name, string Password)
        {
            return db.Users.FirstOrDefault(u => u.Name.Equals(Name) && u.Password.Equals(Password));
        }

        public bool Create(UserRepo obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<UserRepo> Get()
        {
            throw new NotImplementedException();
        }

        public UserRepo Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserRepo obj)
        {
            throw new NotImplementedException();
        }
    }
}
