using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class CharacterClass
    {
        private string className;

        public CharacterClass()
        {
 
        }

        public CharacterClass(string className)
        {
            this.className = className;
        }

        public string GetName()
        {
            return this.className;
        }


    }
}
