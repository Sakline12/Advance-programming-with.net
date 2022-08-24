using BLL.BO;
using DAL;
using DAL.EF;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Doctor_Problem
    {
        public object Doctorproblem_Repo { get; private set; }

        public static List<Doctor_problem_Model> Get()
        {
            var data = DataAccessFactory.GetProblemListDataAccess().Get();
            var rdata = new List<Doctor_problem_Model>();
            foreach (var item in data)
            {
                rdata.Add(new Doctor_problem_Model()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Problem = item.Problem,
                    Reason = item.Reason,
                    Room_no = item.Room_no
                });
            }
            return rdata;
        }
        public static bool Create(Doctor_problem_Model item)
        {
            var problem = new ProblemList()
            {
                
                Name = item.Name,
                Problem = item.Problem,
                Reason = item.Reason,
                Room_no = item.Room_no

            };
            return DataAccessFactory.GetProblemListDataAccess().Create(problem);
        }
        public static bool Update(Doctor_problem_Model item)
        {
            var problem = new ProblemList()
            {
                Id=item.Id,
                Name = item.Name,
                Problem = item.Problem,
                Reason = item.Reason,
                Room_no = item.Room_no

            };

            return DataAccessFactory.GetProblemListDataAccess().Update(problem);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.GetProblemListDataAccess().Delete(id);
        }
        public static Doctor_problem_Model GetOnly(int id)
        {
            var item = DataAccessFactory.GetProblemListDataAccess().Get(id);
            if(item != null)
            {
            var d = new Doctor_problem_Model() {
                Id = item.Id,
                Name = item.Name,
                Problem = item.Problem,
                Reason = item.Reason,
                Room_no = item.Room_no
            };
              return d;
           }
            return null;
            



        }
    }
}
