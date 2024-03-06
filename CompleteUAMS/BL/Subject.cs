using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUAMS.BL
{
    internal class Subject
    {
        public string Code;
        public string Type;
        public int CreditHours;
        public float SubjectFees;
        public Subject(string Code, string Type, int CreditHours, int SubjectFees)
         {
             this.Code = Code;
             this.Type = Type;
             this.CreditHours = CreditHours;
             this.SubjectFees = SubjectFees;
         }
    }
}
