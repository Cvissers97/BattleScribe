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
        // Added casting time
        private string castTime;

        public Spell()
        { 

        }

        public Spell(string name, byte level, string school, string components, string desc, string duration, string atHigherLevels, string castTime)
        {
            this.name = name;
            this.level = level;
            this.school = school;
            this.components = components;
            this.desc = desc;
            this.duration = duration;
            this.atHigherLevels = atHigherLevels;
            this.castTime = castTime;
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

        public byte GetLevel()
        {
            return this.level;
        }

        public void SetLevel(byte level)
        {
            this.level = level;
        }

        public string GetSchool()
        {
            return this.school;
        }

        public void SetSchool(string school)
        {
            this.school = school;
        }

        public string GetComponents()
        {
            return this.components;
        }

        public void SetComponents(string comp)
        {
            this.components = comp;
        }

        public string GetDuration()
        {
            return this.duration;
        }

        public void SetDuration(string dur)
        {
            this.duration = dur;
        }

        public string GetAtHigher()
        {
            return this.atHigherLevels;
        }

        public void SetAtHigher(string higher)
        {
            this.atHigherLevels = higher;
        }

        public string GetCastTime()
        {
            return this.castTime;
        }

        public void SetCastTime(string cast)
        {
            this.castTime = cast;
        }
    }
}
