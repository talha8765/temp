using CompleteUAMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompleteUAMS.UI
{
    internal class SubjectUI
    {
       public static void RegisterSubjects(Student s)
        {
            Console.Write("Enter how many subjevts you want to register: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter subject code: ");
                string code = Console.ReadLine();
                bool Flag = false;
                foreach (Subject sub in s.RegDegree.Subjects)
                {
                    if (code == sub.Code && !(s.RegSubjects.Contains(sub)))
                    {
                        s.RegSubjects.Add(sub);
                        Flag = true;
                        break;
                    }
                }
                if (Flag == false)
                {
                    Console.WriteLine("Enter Valid Course!");
                    i--;
                }
            }
        }



       public static Subject takeInputForSubject()
        {
            string Code;
            string Type;
            int CreditHours;
            int SubjectFees;
            Console.Write("Enter Subject Code: ");
            Code = Console.ReadLine();
            Console.Write("Enter Subject Type: ");
            Type = Console.ReadLine();
            Console.Write("Enter Subject Credit Hours: ");
            CreditHours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fees: ");
            SubjectFees = int.Parse(Console.ReadLine());
            Subject sub = new Subject(Code, Type, CreditHours, SubjectFees);
            return sub;
        }
        public static void viewSubjects(Student s)
        {
            if (s.RegDegree != null)
            {
                Console.WriteLine("Subject Code\tSubject Type");
                foreach (Subject sub in s.RegDegree.Subjects)
                {
                    Console.WriteLine(sub.Code + "\t\t" + sub.Type);
                }
            }
        }
        
    }
}
