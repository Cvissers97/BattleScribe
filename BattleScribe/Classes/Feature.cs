using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class Feature
    {
        public string name;
        public string description;
        public bool hasAcquired;

        public Feature()
        {
 
        }

        public Feature(string name, string description, bool hasAcquired)
        {
            this.name = name;
            this.description = description;
            this.hasAcquired = hasAcquired;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDesc()
        {
            return description;
        }

        public bool AcquiredCheck()
        {
            return hasAcquired;
        }

        public void Acquire(bool acquire)
        {
            this.hasAcquired = acquire;
        }
    }
}
