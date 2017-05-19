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
        ListBox list;

        public LogHandler(ListBox l)
        {
            this.list = l;
        }

        public void DisplayResult(List<int> results)
        {
            string message = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + " - Results: ";

            foreach (int i in results)
            {
                message += "[" + i.ToString() +"]" + " ";
            }

            list.Items.Add(message);
        }
    }
}
