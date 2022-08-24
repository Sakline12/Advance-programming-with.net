using BLL.BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Doctor_Notice
    {
        public object NoticeRepo { get; private set; }

        public static List<Doctor_Notice_Model> Get()
        {
            var data = DataAccessFactory.GetNoticeDataAccess().Get();
            var rdata = new List<Doctor_Notice_Model>();
            foreach (var item in data)
            {
                rdata.Add(new Doctor_Notice_Model()
                {
                  Id = item.Id,
                  Title = item.Title,
                  Details = item.Details,
                  Type = item.Type
                });
            }
            return rdata;
        }
    }
}
