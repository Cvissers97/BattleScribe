using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes.Items
{
    public class Armour : Item
    {
        private bool stealthDisadvantage;
        private int baseArmour;
        private string modifier;
        //Bonus armor can be a negative integer, as well.
        private int bonusArmour;

        public Armour()
        {
 
        }

        public Armour(int id, string name, string description, 
            string type, bool proficient, bool attuneable, double weight,
            bool stealthDisadvantage, int baseArmour, int bonusArmour, string modifier)
            :base(id, name, description, type, proficient, attuneable, weight)
        {
            this.stealthDisadvantage = stealthDisadvantage;
            this.baseArmour = baseArmour;
            this.modifier = modifier;
            this.bonusArmour = bonusArmour;
        }

        public bool GetStealthDis()
        {
            return this.stealthDisadvantage;
        }

        public void SetStealthDis(bool stealthDis)
        {
            this.stealthDisadvantage = stealthDis;
        }

        public int GetBaseArmour()
        {
            return this.baseArmour;
        }

        public void SetBaseArmour(int amount)
        {
            this.baseArmour = amount;
        }

        public string GetModifier()
        {
            return this.modifier;
        }

        public void SetModifier(string mod)
        {
            this.modifier = mod;
        }

        public int GetBonusArmour()
        {
            return this.bonusArmour;
        }

        public void SetBonusAmour(int armour)
        {
            this.bonusArmour = armour;
        }
    }
}
