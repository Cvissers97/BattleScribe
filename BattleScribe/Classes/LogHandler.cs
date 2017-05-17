using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleScribe.Classes
{
    public class LogHandler
    {
        public LogHandler()
        {
 
        }

        public void DisplayResult(List<int> results, ListBox box)
        {
            string message = "Results of the rolls: ";

            foreach (int i in results)
            {
                message += "[" + i.ToString() +"]" + " ";
            }

            box.Items.Add(message);
        }
    }
}
