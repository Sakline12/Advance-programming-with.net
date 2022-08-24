using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo : IRepo<User, int, bool>
    {
        SSHEntities db = new SSHEntities();
        public UserRepo(SSHEntities db)
        {
            this.db = db;
        }


        public bool Create(User obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User us)
        {
            var exst = db.Users.FirstOrDefault(x => x.Id == us.Id);
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(us);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
