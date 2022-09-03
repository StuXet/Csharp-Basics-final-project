using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace FinalProject_MarkGuriev
{

    public class UI
    {
        public List<string> log = new List<string>{" "," "," "," "," "};
         public void AddToList(string addLog)
        {
            log.Insert(0, addLog);
            log.RemoveAt(5);
        }

        public void ListPrint()
        {
            SetCursorPosition(13, 27);
            Console.WriteLine(log[0]);

            SetCursorPosition(13, 28);
            Console.WriteLine(log[1]);

            SetCursorPosition(13, 29);
            Console.WriteLine(log[2]);

            SetCursorPosition(13, 30);
            Console.WriteLine(log[3]);

            SetCursorPosition(13, 31);
            Console.WriteLine(log[4]);
        }
    }
}
