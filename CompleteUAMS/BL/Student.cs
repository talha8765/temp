using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUAMS.BL
{
    internal class Student
    {
        public string Name;
        public int Age;
        public double FscMarks;
        public double EcatMarks;
        public double Merit;
        public List<DegreeProgram> Preferences;
        public List<Subject> RegSubjects;
        public DegreeProgram RegDegree;
        public Student (string Name, int Age, double FscMarks, double EcatMarks, List<DegreeProgram> Preferences)
        {
             this.Name = Name;
             this.Age = Age;
             this.FscMarks = FscMarks;
             this.EcatMarks = EcatMarks;
             this.Preferences = Preferences;
             RegSubjects = new List<Subject>();
        }
        public void CalculateMerit()
        {
            this.Merit = (((FscMarks / 1100) * 0.45F) + ((EcatMarks / 400) * 0.55F)) * 100;

        }
        public bool RegStudentSubject(Subject s)
        {
            int stCH = GetCreditHours();
            if (RegDegree != null && RegDegree.isSubjectExists(s) && stCH + s.CreditHours <= 9)
            {
                RegSubjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetCreditHours()
        {
            int count = 0;
            foreach (Subject s in RegSubjects)
            {
                count = count + s.CreditHours;
            }
            return count;
        }
        public float CalculateFee()
        {
            float fee = 0;
            foreach (Subject s in RegSubjects)
            {
                fee = fee + s.SubjectFees;
            }
            return fee;
        }
    }
}
