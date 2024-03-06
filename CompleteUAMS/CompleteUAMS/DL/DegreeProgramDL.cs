using CompleteUAMS.BL;
using CompleteUAMS.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompleteUAMS.DL
{
    internal class DegreeProgramDL
    {
        public static List<DegreeProgram> programList = new List<DegreeProgram>();
        public static List<Subject> Subjects = new List<Subject>();

        public static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }
        public static void storeintoFile(string path, DegreeProgram d)
        {
            StreamWriter f = new StreamWriter(path, true);
            string SubjectNames = "";
            for (int u = 0; u < d.Subjects.Count - 1; u++)
            {
                SubjectNames = SubjectNames + d.Subjects[u].Type + ";";
            }
            SubjectNames = SubjectNames + d.Subjects[d.Subjects.Count - 1].Type;
            f.WriteLine(d.DegreeName + "," + d.DegreeDuration + "," + d.Seats + "," + SubjectNames);
            f.Flush();
            f.Close();
        }
        

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string degreeName = splittedRecord[0];
                    float degreeDuration = float.Parse(splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] subjects = splittedRecord[3].Split(';');
                    DegreeProgram d = new DegreeProgram(degreeName, degreeDuration, seats);
                    for (int i = 0; i < subjects.Length; i++)
                    {
                        Subject s = Subjects.Find(x => x.Type == subjects[i]);
                        if (s != null)
                        {
                            d.Subjects.Add(s);
                        }
                    }
                    addIntoDegreeList(d);
                }
                f.Close();
                return true;
            }
            else
                return false;
        }

    }
}
