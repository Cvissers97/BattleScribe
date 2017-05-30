using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes.Items
{
    public class Weapon : Item
    {
        private string damage;
        private string modifier;
        //Bonus damage can be positive and negative.
        private float bonusDamage;
        private string baseDamageType;
        private string bonusDamageType;

        public Weapon()
        {
 
        }

        public Weapon(int id, string name, string description,
            string damage, string type,
            bool proficient, bool attuneable, string weight,
            string modifier, float bonusDamage, string baseDamageType,
            string bonusDamageType, int quantity)
            : base(id, name, description, type, proficient, attuneable, weight, quantity)
        {
            this.damage = damage;
            this.modifier = modifier;
            this.bonusDamage = bonusDamage;
            this.baseDamageType = baseDamageType;
            this.bonusDamageType = bonusDamageType;
        }

        public Weapon(int id, string name, string description, 
            string damage,  string type, 
            bool proficient, bool attuneable, string weight,
            string modifier, float bonusDamage, string baseDamageType, 
            string bonusDamageType, int quantity, int charInvId)
            :base(id, name, description, type, proficient, attuneable, weight, quantity)
        {
            this.damage = damage;
            this.modifier = modifier;
            this.bonusDamage = bonusDamage;
            this.baseDamageType = baseDamageType;
            this.bonusDamageType = bonusDamageType;
            this.charInvId = charInvId;
        }

        public string GetDamage()
        {
            return this.damage;
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
            if (bonusDamageType == "geen idee")
            {
                return string.Empty;
            }

            return this.bonusDamageType;
        }

        public void SetBonusDamageType(string type)
        {
            this.bonusDamageType = type;
        }

        public string GetDamageForCopy()
        {
            return this.damage;
        }
    }
}
