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
        private int classId;

        public CharacterClass()
        {
 
        }

        public CharacterClass(string className, int classId)
        {
            this.className = className;
            this.classId = classId;

        }

        public string GetName()
        {
            return this.className;
        }

        public int GetId()
        {
            return classId;
        }

    }
}
