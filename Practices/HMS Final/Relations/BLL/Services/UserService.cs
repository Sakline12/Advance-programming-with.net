using BLL.BOS;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static List<StudentModel> Get()
        {
            var data = DataAccessFactory.GetStudentDataAccess().Get();
            var depts = new List<StudentModel>();
            foreach (var item in data)
            {
                depts.Add(new StudentModel() { Id = item.Id, Name = item.Name });
            }
            return depts;
        }
    }
}