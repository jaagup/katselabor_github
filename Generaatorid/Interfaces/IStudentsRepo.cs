using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katselabor.Interfaces
{
    public interface IStudentsRepo
    {
        // add studnet to db
        void addStudent(students model);
        // get student by name
        IList<students> getAllStudentsByName(string searchQ);
        // get all students
        IList<students> getAllStudents();
    }
}
