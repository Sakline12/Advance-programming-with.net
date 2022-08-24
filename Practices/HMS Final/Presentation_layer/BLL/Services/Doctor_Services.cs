using BLL.BO;
using DAL;
using DAL.EF;
using DAL.Interface;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Doctor_Services
    {
        public static List<Doctor_Model> Get()
        {
            var data = DataAccessFactory.GetRegistrationDataAccess().Get();
            var rdata = new List<Doctor_Model>();
            foreach (var item in data)
            {
                rdata.Add(new Doctor_Model()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,   
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Type = item.Type,
                    Blood_group = item.Blood_group,
                    Department = item.Department,
                    Degree = item.Degree


                    
                });
            }
            return rdata;
        }
        public static bool Create(Doctor_Model item)
        {
            var doctor = new Registration()
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Age = item.Age,
                Gender = item.Gender,
                Email = item.Email,
                Phone_no = item.Phone_no,
                Type = item.Type,
                Blood_group = item.Blood_group,
                Department = item.Department,
                Degree = item.Degree

            };
            return DataAccessFactory.GetRegistrationDataAccess().Create(doctor);
        }
        public static bool Update(Doctor_Model item)
        {
            var doctor = new Registration()
           
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Age = item.Age,
                Gender = item.Gender,
                Email = item.Email,
                Phone_no = item.Phone_no,
                Type = item.Type,
                Blood_group = item.Blood_group,
                Department = item.Department,
                Degree = item.Degree

            };

            return DataAccessFactory.GetRegistrationDataAccess().Update(doctor);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.GetRegistrationDataAccess().Delete(id);
        }
        public static Doctor_Model GetOnly(int id)
        {
            var item = DataAccessFactory.GetRegistrationDataAccess().Get(id);
            if(item !=null)
            {
                var d = new Doctor_Model()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Type = item.Type,
                    Blood_group = item.Blood_group,
                    Department = item.Department,
                    Degree = item.Degree

                };
                return d;

            }
            return null;

        }
    }
}
