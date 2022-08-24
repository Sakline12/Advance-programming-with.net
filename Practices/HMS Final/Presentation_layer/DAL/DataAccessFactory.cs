using DAL.EF;
using DAL.Interface;
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
        static HospitalEntities db = new HospitalEntities();
         public static IRepo_doctor<Registration, int , bool> GetRegistrationDataAccess()
        {
            return new DoctorRepo(db);
        }
        public static IRepo_doctor<ProblemList, int, bool> GetProblemListDataAccess()
        {
            return new Doctor_problem_Repo(db);
        }
        public static IRepo_doctor<Appointment, int, bool> GetAppointmentDataAccess()
        {
            return new AppointmentRepo(db);
        }
        public static IRepo_doctor<Donor, int, bool> GetDonorDataAccess()
        {
            return new Doctor_DonorRepo(db);
        }
/*        public static IRepo_doctor<User,string,bool> GetUserDataAccess()
        {
            return new UserRepo(db);
        }*/
        public static IAuth<User> GetAuthDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepo_doctor<Token,string,Token> GetTokenDataAccess()
        {
            return new TokenRepo(db);
        }
        public static IRepo_doctor<Notice, int, bool> GetNoticeDataAccess()
        {
            return new NoticeRepo(db);
        }
        public static IRepo_doctor<Epatient, int, bool> GetEpatientDataAccess()
        {
            return new EpatientRepo(db);
        }
    }
}
