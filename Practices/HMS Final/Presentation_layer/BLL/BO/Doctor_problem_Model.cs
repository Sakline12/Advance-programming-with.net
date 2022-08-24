using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BO
{
    public class Doctor_problem_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Problem { get; set; }
        public string Reason { get; set; }
        public int Room_no { get; set; }
    }
}
