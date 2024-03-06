using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompleteUAMS.BL;

namespace CompleteUAMS.DL
{
    internal class SubjectDL
    {
        public static List<Subject> Subjects = new List<Subject>();

        public static void storeintoFile(string path, Subject s)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(s.Code + "," + s.Type + "," + s.CreditHours + "," + s.SubjectFees);
            f.Flush();
            f.Close();
        }
       
    }
}
