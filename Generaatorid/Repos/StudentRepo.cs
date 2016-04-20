using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using katselabor.Interfaces;
using NLog;

namespace katselabor.Repos
{
    public class StudentRepo : IStudentsRepo
    {

        // Initialize logging stuff
        private static Logger logger = LogManager.GetCurrentClassLogger();

        void IStudentsRepo.addStudent(students model)
        {
            using (var ctx = new katselaborEntities())
            {
                ctx.students.Add(model);
                ctx.SaveChanges();

                logger.Info("Saving to db something");
            }
        }

        IList<students> IStudentsRepo.getAllStudents()
        {
            using (var ctx = new katselaborEntities())
            {
                var list = new List<students>();

                foreach (var student in ctx.students)
                    list.Add(student);

                logger.Info("Hopefully returning all students");
                return list.ToArray();

            }
        }

        IList<students> IStudentsRepo.getAllStudentsByName(string searchQ)
        {
            using (var ctx = new katselaborEntities())
            {
                var list = new List<students>();
                var L2EQuery = from st in ctx.students
                                where st.name.Contains(searchQ)
                                select st ;
                //tagastab kõik %LIKE% searchQ
                var student = L2EQuery.ToArray<students>();
                for(int i = 0; i< student.Length; i++)
                {
                    list.Add(student[i]);
                }
                // tagastab listi
                logger.Info("Hopefully returning more than 1 student matching");
                return list.ToArray();
            }
        }
    }
}
