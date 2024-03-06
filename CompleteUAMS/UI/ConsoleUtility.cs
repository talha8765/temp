using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUAMS.UI
{
    internal class ConsoleUtility
    {
        public static void header()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
               ooooo     ooo       .o.       ooo        ooooo  .oooooo..o 
               `888'     `8'      .888.      `88.       .888' d8P'    `Y8 
                888       8      .8""888.      888b     d'888  Y88bo.      
                888       8     .8' `888.     8 Y88. .P  888   `""Y8888o.  
                888       8    .88ooo8888.    8  `888'   888       `""Y88b 
                `88.    .8'   .8'     `888.   8    Y     888  oo     .d8P 
                  `YbodP'    o88o     o8888o o8o        o888o 8""""88888P'  
                                                           ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int menu()
        {
            header();
            int option;
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Your Option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
