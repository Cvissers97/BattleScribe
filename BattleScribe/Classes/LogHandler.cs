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

            list.Items.Insert(0, message);
        }

        public void Write(string text)
        {
            string message = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + " - " + text;
            list.Items.Insert(0, message);
        }

        public void InputSpace()
        {
            list.Items.Insert(0, "");
        }

        public void ClearAll()
        {
            list.Items.Clear();
        }
    }
}
