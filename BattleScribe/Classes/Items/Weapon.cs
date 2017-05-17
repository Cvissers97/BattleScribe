using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes.Items
{
    public class Weapon : Item
    {
        private int diceAmount;
        private int diceSides;
        private string modifier;
        //Bonus damage can be positive and negative.
        private int bonusDamage;

        private string baseDamageType;
        private string bonusDamageType;

        public Weapon()
        {
 
        }

        public Weapon(int id, string name, string description, 
            int diceAmount, int diceSides,  string type, 
            bool proficient, bool attuneable, double weight,
            string modifier, int bonusDamage, string baseDamageType, 
            string bonusDamageType)
            :base(id, name, description, type, proficient, attuneable, weight)
        {
            this.diceAmount = diceAmount;
            this.diceSides = diceSides;
            this.modifier = modifier;
            this.bonusDamage = bonusDamage;
            this.baseDamageType = baseDamageType;
            this.bonusDamageType = bonusDamageType;
        }

        public int GetDiceAmount()
        {
            return this.diceAmount;
        }

        public void SetDiceAmount(int amount)
        {
            this.diceAmount = amount;
        }

        public int GetDiceSides()
        {
            return this.diceSides;
        }

        public void SetDiceSides(int amount)
        {
            this.diceSides = amount;
        }

        public string GetModifier()
        {
            return this.modifier;
        }

        public double GetBonusDamage()
        {
            return this.bonusDamage;
        }

        public void SetBonusDamage(int amount)
        {
            this.bonusDamage = amount;
        }

        public string GetBaseDamageType()
        {
            return this.baseDamageType;
        }

        public void SetBaseDamageType(string type)
        {
            this.baseDamageType = type;
        }

        public string GetBonusDamageType()
        {
            return this.bonusDamageType;
        }

        public void SetBonusDamageType(string type)
        {
            this.bonusDamageType = type;
        }
    }
}
