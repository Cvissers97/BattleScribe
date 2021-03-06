﻿using System;
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
        private int strReq;

        public Armour()
        {
 
        }

        public Armour(int id, string name, string description, 
            string type, bool proficient, bool attuneable, string weight,
            bool stealthDisadvantage, int baseArmour, int bonusArmour, string modifier, int quantity, int strReq, string estimatedValue)
            :base(id, name, description, type, proficient, attuneable, weight, quantity)
        {
            this.stealthDisadvantage = stealthDisadvantage;
            this.baseArmour = baseArmour;
            this.modifier = modifier;
            this.bonusArmour = bonusArmour;
            this.strReq = strReq;
            this.estimateValue = estimatedValue;
        }

        public Armour(int id, string name, string description,
            string type, bool proficient, bool attuneable, string weight,
            bool stealthDisadvantage, int baseArmour, int bonusArmour, string modifier, int quantity, int strReq, string estimatedValue, int charInvId)
            : base(id, name, description, type, proficient, attuneable, weight, quantity)
        {
            this.stealthDisadvantage = stealthDisadvantage;
            this.baseArmour = baseArmour;
            this.modifier = modifier;
            this.bonusArmour = bonusArmour;
            this.strReq = strReq;
            this.estimateValue = estimatedValue;
            this.charInvId = charInvId;
        }

        public Armour(string name, string desc, bool reqProf, int acBonus, int ac, string mod, int strReq, bool stealthDis, string weight, string cost, string type, bool attunable)
        {
            this.name = name;
            this.description = desc;
            this.proficient = reqProf;
            this.bonusArmour = acBonus;
            this.baseArmour = ac;
            this.modifier = mod;
            this.strReq = strReq;
            this.stealthDisadvantage = stealthDis;
            this.weight = weight;
            this.estimateValue = cost;
            this.type = type;
            this.attuneable = attuneable;
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

        public int GetStrReq()
        {
            return this.strReq;
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
