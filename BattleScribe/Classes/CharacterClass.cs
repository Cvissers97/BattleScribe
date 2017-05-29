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
        private string savThrow1, savThrow2, weaponProfs, armourProfs, toolProfs;

        public CharacterClass()
        {
 
        }

        public CharacterClass(string className, int classId)
        {
            this.className = className;
            this.classId = classId;

        }

        public CharacterClass(string name, int id, string savThrow1, string savThrow2, string weaponProfs, string armourProfs, string toolProfs)
        {
            this.classId = id;
            this.className = name;
            this.savThrow1 = savThrow1;
            this.savThrow2 = savThrow2;
            this.weaponProfs = weaponProfs;
            this.armourProfs = armourProfs;
            this.toolProfs = toolProfs;
        }

        public string GetSavThrow1()
        {
            return savThrow1;
        }

        public string GetSavThrow2()
        {
            return savThrow2;
        }

        public string GetWepProfs()
        {
            return weaponProfs;
        }

        public string GetArmourProfs()
        {
            return armourProfs;
        }

        public string GetToolProfs()
        {
            return toolProfs;
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
