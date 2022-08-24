using BLL.BO;
using DAL.EF;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Student_Services
    {
        public object Student_Repo { get; private set; }

        public static List<Student_Model> Get()
        {
            var data = StudentRepo.Get();
            var rdata = new List<Student_Model>();
            foreach (var item in data)
            {
                rdata.Add(new Student_Model()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Fname = item.Fname,
                    CGPA = item.CGPA
                });
            }
            return rdata;
        }

        public static Student_Model GetOnly(int id)
        {
            var item = StudentRepo.Get(id);
            var d = new Student_Model() { Id = item.Id, Name = item.Name, Fname = item.Fname,CGPA=item.CGPA };
            return d;



        }


        /*        public static bool Get(int id)
                {
                    return StudentRepo.Get(id);
                }*/

        /*        public static List<Student_Model> Count(int count)
                {
                    return StudentRepo.Get().Take(count).ToList();
                }*/
        public static bool Create(Student_Model item)
        {
            var student = new Student()
            {
                Id = item.Id,
                Name = item.Name,
                Fname = item.Fname,
                CGPA = item.CGPA
            };
            return StudentRepo.Create(student);
        }
            public static bool Delete(int id)
            {
                return StudentRepo.Delete(id);
            }
        public static bool Update(Student_Model item)
        {
            var student = new Student()
            {
                Id=item.Id,
                Name=item.Name,
                Fname=item.Fname,
                CGPA=item.CGPA

            };

            return StudentRepo.Update(student);
        }



    }

    }

    