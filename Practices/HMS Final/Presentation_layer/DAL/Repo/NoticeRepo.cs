using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NoticeRepo : IRepo_doctor<Notice, int, bool>
    {
        HospitalEntities db;

        public NoticeRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public bool Create(Notice obj)
        {
            db.Notices.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notice> Get()
        {
            return db.Notices.ToList();
        }

        public Notice Get(int id)
        {
            var single = db.Notices.Find(id);
            if (single != null)
            {
                return single;
            }
            return null;
        }

        public bool Update(Notice obj)
        {
            throw new NotImplementedException();
        }
    }
}
