using CompleteUAMS.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUAMS.DL
{
    internal class StudentDL
    {
        public static List<Student> studentList = new List<Student>();
        public static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.Name && s.RegDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedStudentList = new List<Student>();
            foreach (Student s in studentList)
            {
                s.CalculateMerit();
            }
            sortedStudentList = studentList.OrderByDescending(o => o.Merit).ToList();
            return sortedStudentList;
        }
        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProgram d in s.Preferences)
                {
                    if (d.Seats > 0 && s.RegDegree == null)
                    {
                        s.RegDegree = d;
                        d.Seats = d.Seats - 1;
                        break;
                    }
                }
            }
        }

        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }
        public static void storeintoFile(string path, Student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string DegreeNames = "";
            for (int i = 0; i < s.Preferences.Count - 1; i++)
            {
                DegreeNames = DegreeNames + s.Preferences[i].DegreeName + ";";
            }
            DegreeNames = DegreeNames + s.Preferences[s.Preferences.Count - 1].DegreeName;
            f.WriteLine(s.Name + "," + s.Age + "," + s.FscMarks + "," + s.EcatMarks + "," + DegreeNames);
            f.Flush();
            f.Close();

        }
       
    }
}

