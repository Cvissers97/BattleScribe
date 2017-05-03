using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScribe.Classes.Items
{
    class Item
    {
        protected string name;
        protected string description;
        protected string type;
        protected bool proficient;
        protected bool attuneable;
        protected double weight;

        public Item()
        {

        }

        public Item(string name, string description, string type, bool proficient, bool attuneable, double weight)
        {
            this.name = name;
            this.description = description;
            this.type = type;
            this.proficient = proficient;
            this.attuneable = proficient;
            this.weight = weight;
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

        public double GetWeight()
        {
            return this.weight;
        }

        public void SetWeight(double weight)
        {
            this.weight = weight;
        }
    }
}
