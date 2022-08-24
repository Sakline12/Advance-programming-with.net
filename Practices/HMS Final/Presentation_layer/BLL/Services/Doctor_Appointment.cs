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
    public class Doctor_Appointment
    {
        public object Appointment_Repo { get; private set; }

        public static List<Doctor_Appointment_Model> Get()
        {
            var data = DataAccessFactory.GetAppointmentDataAccess().Get();
            var rdata = new List<Doctor_Appointment_Model>();
            foreach (var item in data)
            {
                rdata.Add(new Doctor_Appointment_Model()
                {
                    Id = item.Id,
                    Patient_Name = item.Patient_Name,
                    Problem_list = item.Problem_list,
                    Prescription_File = item.Prescription_File

                });
            }
            return rdata;
        }

        public static bool Update(Doctor_Appointment_Model item)
        {
            var appointment = new Appointment()
            {
                Id = item.Id,
                Patient_Name = item.Patient_Name,
                Problem_list = item.Problem_list,
                Prescription_File = item.Prescription_File,
                Doctor_Name = item.Doctor_Name,
                Prescription = item.Prescription,
                Payment_status = item.Payment_status,
                Prescribed = item.Prescribed,
            };
            return DataAccessFactory.GetAppointmentDataAccess().Update(appointment);
        }
    }
}
