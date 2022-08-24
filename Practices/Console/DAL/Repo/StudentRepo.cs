using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class StudentRepo
    {
        static First_data_baseEntities db = new First_data_baseEntities();
        public static List<Student> Get()
        {
            return db.Students.ToList();
        }

        public static Student Get(int id)
        {
            var department = db.Students.Find(id);
            return department;
        }

        /*        public static Student Get(int id)
                {
                    return db.Students.SingleOrDefault(s => s.Id == id);
                }*/

        public static Student Count(int id)
        {
            return db.Students.SingleOrDefault(s => s.Id == id);
        }


        public static bool Create(Student student)
        {
            db.Students.Add(student);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }
        public static bool Update(Student student)
        {
            var est = db.Students.FirstOrDefault(x => x.Id == student.Id);
            if (est != null)
            {
                db.Entry(est).CurrentValues.SetValues(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool Delete(int id)
        {
            var dlts = db.Students.FirstOrDefault(x => x.Id == id);
            if (dlts !=null)
            {
                db.Students.Remove(dlts);
                db.SaveChanges();
                return true;
            }
            return false;


        }

    }
}
