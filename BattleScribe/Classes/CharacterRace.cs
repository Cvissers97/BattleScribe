using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes
{
    public class CharacterRace
    {
        private string name;
        public List<Feature> features;

        public CharacterRace()
        {
            
        }

        public CharacterRace(string name)
        {
            this.name = name;
            //this.features = features;
        }

        public string GetName()
        {
            return name;
        }

        public List<Feature> GetFeatures()
        {
            return features;
        }
    }
}
