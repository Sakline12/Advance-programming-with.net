using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOS
{
    public class StudentUserModel : UserModel
    {
        public List<StudentModel> Users { get; set; }
        public StudentUserModel()
        {
            Users = new List<StudentModel>();
        }

    }
}