using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static SSHEntities db = new SSHEntities();
        public static IRepo<User, int, bool> GetUserDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepo<Student, int, bool> GetStudentDataAccess()
        {
            return new StudentRepo(db);
        }
    }
}
