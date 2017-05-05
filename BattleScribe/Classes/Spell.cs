using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class Spell
    {
        private string name;
        private byte level;
        private string school;
        private string components;
        private string desc;
        private string duration;
        private string atHigherLevels;

        public Spell()
        { 

        }

        public Spell(string name, byte level, string school, string components, string desc, string duration, string atHigherLevels)
        {
            this.name = name;
            this.level = level;
            this.school = school;
            this.components = components;
            this.desc = desc;
            this.duration = duration;
            this.atHigherLevels = atHigherLevels;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetDesc()
        {
            return this.desc;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetDesc(string desc)
        {
            this.desc = desc;
        }
    }
}
