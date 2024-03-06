using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUAMS.BL
{
    internal class DegreeProgram
    {
        public string DegreeName;
        public float DegreeDuration;
        public List<Subject> Subjects;
        public int Seats;
        public DegreeProgram(string DegreeName, float DegreeDuration, int Seats)
        {
             this.DegreeName = DegreeName;
             this.DegreeDuration = DegreeDuration;
             this.Seats = Seats;
             Subjects = new List<Subject>();
        }
        public int CalculateCreditHours()
        {
            int count = 0;
            for (int i = 0; i < Subjects.Count; i++)
            {
                count = count + Subjects[i].CreditHours;
            }
            return count;
        }
        public bool AddSubject(Subject s)
        {
            int creditHours = CalculateCreditHours();
            if (creditHours + s.CreditHours <= Seats)
            {
                Subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isSubjectExists(Subject sub)
        {
            foreach (Subject s in Subjects)
            {
                if (s.Code == sub.Code)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
