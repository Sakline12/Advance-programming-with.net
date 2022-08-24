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
    public class Donor_Approve
    {
        public static List<Doctor_donor_Model> Get()
        {
            var data = DataAccessFactory.GetDonorDataAccess().Get();
            var rdata = new List<Doctor_donor_Model>();
            foreach (var item in data)
            {
                rdata.Add(new Doctor_donor_Model()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Gender = item.Gender,
                    Phone_no = item.Phone_no,   
                    Blood_group = item.Blood_group,
                    Organ_type = item.Organ_type,
                    Blood_pressure = item.Blood_pressure,
                    Diabetes = item.Diabetes,
                    Allergy = item.Allergy,
                    Asthama = item.Asthama,
                    Approval = item.Approval,
                    Approved_by = item.Approved_by,
                    Location = item.Location
                });
            }
            return rdata;
        }
        public static bool Update(Doctor_donor_Model item)
        {
            var donor = new Donor()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Gender = item.Gender,
                Phone_no = item.Phone_no,
                Blood_group = item.Blood_group,
                Organ_type = item.Organ_type,
                Blood_pressure = item.Blood_pressure,
                Diabetes = item.Diabetes,
                Allergy = item.Allergy,
                Asthama = item.Asthama,
                Approval = item.Approval,
                Approved_by = item.Approved_by,
                Location = item.Location

            };

            return DataAccessFactory.GetDonorDataAccess().Update(donor);
        }
    }
}
