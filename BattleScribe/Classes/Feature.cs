using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class Feature
    {
        public int id;
        public string name;
        public string description;

        public Feature()
        {
 
        }

        public Feature(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDesc()
        {
            return description;
        }
    }
}
