using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class Feat
    {
        public string name;
        public string description;
        public string prereq;
        public int id;

        public Feat()
        {

        }

        public Feat(string name, string description, string prereq, int id)
        {
            this.name = name;
            this.description = description;
            this.prereq = prereq;
            this.id = id;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDesc()
        {
            return description;
        }

        public override string ToString()
        {
            //Overriding ToString so comboboxes/listboxes display the name of the feat
            return name;
        }

        public string GetPrereq()
        {
            return prereq;
        }
    }
}
