using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DoctorRepo :IRepo_doctor<Registration,int,bool>
    {
        HospitalEntities db;

        public DoctorRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public User Authenticate(string Name, string Password)
        {
            return db.Users.FirstOrDefault(u => u.Name.Equals(Name) && u.Password.Equals(Password));
        }

        public bool Create(Registration obj)
        {
            db.Registrations.Add(obj);
            var res=db.SaveChanges();
            if(res !=0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var dlts = db.Registrations.FirstOrDefault(x => x.Id == id);
            if (dlts != null)
            {
                db.Registrations.Remove(dlts);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Registration> Get()
        {
            return db.Registrations.ToList();
        }

        public Registration Get(int id)
        {
            var single = db.Registrations.Find(id);
            if(single !=null)
            {
              return single;
            }
            return null;
        }

        public bool Update(Registration obj)
        {
            var est = db.Registrations.FirstOrDefault(x => x.Id == obj.Id);
            if (est != null)
            {
                db.Entry(est).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(DoctorRepo obj)
        {
            throw new NotImplementedException();
        }



    }
}
