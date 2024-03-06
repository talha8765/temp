using CompleteUAMS.BL;
using CompleteUAMS.DL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUAMS.UI
{
    internal class DegreeProgramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            string DegreeName;
            float DegreeDuration;
            int Seats;
            Console.Write("Enter Degree Name: ");
            DegreeName = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            DegreeDuration = float.Parse(Console.ReadLine());
            Console.Write("Enter Number of Seats for Degree Program: ");
            Seats = int.Parse(Console.ReadLine());
            DegreeProgram degProg = new DegreeProgram(DegreeName, DegreeDuration, Seats);

            Console.Write("Enter how many subjects you want to enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                degProg.AddSubject(SubjectUI.takeInputForSubject());
            }
            return degProg;
        }
        public static void viewDegreePrograms()
        {
            foreach (DegreeProgram d in DegreeProgramDL.programList)
            {
                Console.WriteLine(d.DegreeName);
            }
        }
    }
}
