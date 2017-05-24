using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class Spell
    {
        private string id;
        private string name;
        private byte level;
        private string school;
        private string components;
        private string desc;
        private string duration;
        private string atHigherLevels;
        // Added casting time
        private string castTime;
        private string range;
        private bool isPrepared;

        public Spell()
        { 

        }

        public Spell(string id ,string name, byte level, string school, string castTime, string range, string components, string duration, string desc, string atHigherLevels, bool isPrepared)
        {
            this.id = id;
            this.name = name;
            this.level = level;
            this.school = school;
            this.castTime = castTime;
            this.range = range;
            this.components = components;
            this.duration = duration;
            this.desc = desc;
            this.atHigherLevels = atHigherLevels;
            this.isPrepared = isPrepared;
        }

        public override string ToString()
        {
            return this.name;
        }

        public string GetId()
        {
            return this.id;
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

        public string GetHigher()
        {
            return this.atHigherLevels;
        }

        public string GetRange()
        {
            return this.range;  
        }

        public bool GetPrepared()
        {
            return this.isPrepared;
        }
    }
}
