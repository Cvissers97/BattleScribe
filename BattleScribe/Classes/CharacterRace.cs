using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class CharacterRace
    {
        private int id;
        private string name;
        public List<Feature> features;

        public CharacterRace()
        {
            
        }

        public CharacterRace(int id, string name)
        {
            this.name = name;
            this.id = id;
        }

        public string GetName()
        {
            return name;
        }

        public int GetId()
        {
            return this.id;
        }

        public List<Feature> GetFeatures()
        {
            return features;
        }
    }
}
