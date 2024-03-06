using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompleteUAMS.BL;
using CompleteUAMS.DL;
using CompleteUAMS.UI;
using System.IO;

namespace CompleteUAMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "subject.txt";
            string studentpath = "student.txt";
            string degreepath = "degree.txt";
            if (!File.Exists(subjectPath))
            {
                File.Create(subjectPath);
            }
            if (!File.Exists(studentpath))
            {
                File.Create(studentpath);
            }
            if (!File.Exists(degreepath))
            {
                File.Create(degreepath);
            }
           
           
            int option;
            do
            {
                Console.Clear();

                option = ConsoleUtility.menu();
                if (option == 1)
                {
                    if (DegreeProgramDL.programList.Count > 0)
                    {
                        Student s = StudentUI.takeInputForStudent();
                        StudentDL.addIntoStudentList(s);
                        StudentDL.storeintoFile(studentpath, s);
                    }
                    else
                    {
                        Console.WriteLine("Add Programs First!");
                    }
                }
                else if (option == 2)
                {
                    DegreeProgram d = DegreeProgramUI.takeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(d);
                    DegreeProgramDL.storeintoFile(degreepath, d);
                }
                else if(option == 3)
                {
                    List <Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.sortStudentsByMerit();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                }
                else if(option == 4)
                {
                    StudentUI.viewRegisteredStudents();
                }
                else if(option == 5)
                {
                    string DegreeName;
                    Console.Write("Enter Degree Name: ");
                    DegreeName = Console.ReadLine();
                    StudentUI.viewStudentInDegree(DegreeName);
                }
                else if(option == 6)
                {
                    Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student s = StudentDL.StudentPresent(name);
                    if(s != null)
                    {
                        SubjectUI.viewSubjects(s);
                        SubjectUI.RegisterSubjects(s);
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }
                }
                else if(option == 7)
                {
                    StudentUI.calculateFeeForAll();
                }
                else
                {
                    break;
                }
                Console.ReadKey();
                
            } while (option != 8);
        }
    }
}
