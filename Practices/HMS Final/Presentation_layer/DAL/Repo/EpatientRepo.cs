using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class EpatientRepo: IRepo_doctor<Epatient, int, bool>
    {
        HospitalEntities db;

        public EpatientRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public bool Create(Epatient obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Epatient> Get()
        {
            return db.Epatients.ToList();
        }

        public Epatient Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Epatient obj)
        {
            var est = db.Epatients.FirstOrDefault(x => x.Id == obj.Id);
            if (est != null)
            {
                db.Entry(est).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
