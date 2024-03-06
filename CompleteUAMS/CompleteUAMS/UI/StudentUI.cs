using CompleteUAMS.BL;
using CompleteUAMS.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUAMS.UI
{
    internal class StudentUI
    {
        public static void calculateFeeForAll()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.RegDegree != null)
                {
                    Console.WriteLine(s.Name + " " + s.CalculateFee() + " fees");

                }

            }
        }
        public static void printStudents()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.RegDegree != null)
                {
                    Console.WriteLine(s.Name + " got Admission in " + s.RegDegree.DegreeName);
                }
                else
                {
                    Console.WriteLine(s.Name + " did not get Admission");
                }
            }
        }
        public static void viewStudentInDegree(string DegName)
        {
            Console.WriteLine("Name\tAge\tFscMarks\tEcatMarks");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.RegDegree != null && s.RegDegree.DegreeName == DegName)
                {
                    Console.WriteLine(s.Name + "\t" + s.Age + "\t" + s.FscMarks + "\t" + s.EcatMarks);
                }
            }
        }
        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tAge\tFscMarks\tEcatMarks");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.RegDegree != null)
                {
                    Console.WriteLine(s.Name + "\t" + s.Age + "\t" + s.FscMarks + "\t\t" + s.EcatMarks);
                }
            }
        }
        public static Student takeInputForStudent()
        {
            string Name;
            int Age;
            double FscMarks;
            double EcatMarks;
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.Write("Enter Student Name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Fsc Marks: ");
            FscMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat Marks: ");
            EcatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs");
            DegreeProgramUI.viewDegreePrograms();
            Console.Write("Enter how many preferences you want to opt: ");
            int Count = int.Parse(Console.ReadLine());
            for (int i = 0; i < Count; i++)
            {
                string DegName = Console.ReadLine();
                bool Flag = false;
                foreach (DegreeProgram dp in DegreeProgramDL.programList)
                {
                    if (DegName == dp.DegreeName)
                    {
                        if (!(preferences.Contains(dp)))
                        {
                            preferences.Add(dp);
                            Flag = true;
                        }
                    }
                }
                if (Flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name: ");
                    i--;
                }
            }
            Student s = new Student(Name, Age, FscMarks, EcatMarks, preferences);
            return s;
        }

    }
}
