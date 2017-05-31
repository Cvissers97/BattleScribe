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
        private string damage2;
        private string baseDamageType2;
        private string properties;

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

        public Weapon(string name, string damage, string damage2, string damageType, string damageType2
            , string properties, string desc, string bonusType, string mod, int bonusDamage)
        {
            this.name = name;
            this.damage = damage;
            this.damage2 = damage2;
            this.baseDamageType = damageType;
            this.baseDamageType2 = damageType2;
            this.properties = properties;
            this.description = desc;
            this.bonusDamageType = bonusType;
            this.modifier = mod;
            this.bonusDamage = bonusDamage;
        }


        public string GetDamage()
        {
            return this.damage;
        }
        public string GetProperties()
        {
            return this.properties;
        }

        public void SetProperties(string properties)
        {
            this.properties = properties;
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

        public string GetDamage2()
        {
            return damage2;
        }

        public string GetBaseDamage2()
        {
            return baseDamageType2;
        }

        public void SetDamage2(string target)
        {
            this.damage2 = target;
        }

        public void SetBaseDamage2(string target)
        {
            this.baseDamageType2 = target;
        }
    }
}
