using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes.Items
{
    public class Item
    {
        protected string name;
        protected string description;
        protected string type;
        protected bool proficient;
        protected bool attuneable;
        protected string weight;
        protected string estimateValue;
        protected bool isEquip;
        protected int id, quantity;

        public Item()
        {

        }

        public Item(int id, string name, string cost, string weight, int typeId, int quantity)
        {
            this.id = id;
            this.name = name;
            this.estimateValue = cost; ;
            this.weight = weight;
            this.type = typeId.ToString();
            this.quantity = quantity;
            if (this.quantity == 0)
            {
                this.quantity = 1;
            }
        }

        public Item(int id, string name, string description, string type, bool proficient, bool attuneable, string weight, int quantity)
        {
            this.name = name;
            this.description = description;
            this.type = type;
            this.proficient = proficient;
            this.attuneable = proficient;
            this.weight = weight;
            this.id = id;
            isEquip = false;
            this.quantity = quantity;
            if (this.quantity == 0)
            {
                this.quantity = 1;
            }
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public string GetItemType()
        {
            return this.type;
        }

        public void SetItemType(string type)
        {
            this.type = type;
        }

        public bool GetProficient()
        {
            return this.proficient;
        }

        public void SetProficient(bool proficient)
        {
            this.proficient = proficient;
        }

        public bool GetAttunement()
        {
            return this.attuneable;
        }

        public void SetAttunement(bool attuneable)
        {
            this.attuneable = attuneable;
        }

        public string GetWeight()
        {
            return this.weight;
        }

        public void SetWeight(string weight)
        {
            this.weight = weight;
        }

        public string GetValue()
        {
            return estimateValue;
        }

        public void SetValue(string estimateValue)
        {
            this.estimateValue = estimateValue;
        }

        public bool GetEquip()
        {
            return isEquip;
        }

        public void SetEquip(bool equip)
        {
            isEquip = equip;
        }

        public int GetId()
        {
            return this.id;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

        public void IncrementQuantity()
        {
            this.quantity += 1;
        }
    }
}
