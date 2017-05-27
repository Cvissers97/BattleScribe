using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleScribe.Classes;
using BattleScribe.Classes.Items;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BattleScribe.Controls.Items;

namespace BattleScribe.Classes
{
    public class InventoryManager
    {
        private Label lbCarry;
        private DbHandler db;

        public Character c;

        private List<Item> items;
        private List<Weapon> weapons;
        private List<Armour> armours;

        private List<Item> allItems;
        private StackPanel stack;
        private List<Item> equipedItems;

        double totalItemWeight;


        public InventoryManager(Character c, StackPanel stack, Label carry)
        {
            this.c = c;
            this.stack = stack;
            this.lbCarry = carry;

            weapons = new List<Weapon>();
            armours = new List<Armour>();
            items = new List<Item>();
            equipedItems = new List<Item>();

            allItems = new List<Item>();
            db = new DbHandler();

            GetInventory();
            UpdateInventory();
        }

        private void GetInventory()
        {
            weapons = db.GetWeaponsByCharId(c.GetID());
            armours = db.GetArmoursByCharId(c.GetID());
            items = db.GetItemsByCharId(c.GetID());
        }

        public void SaveInventory()
        {
            db.InsertInventory(allItems, c.GetID());
        }

        private void UpdateInventory()
        {
            // Making childeren : ^)
            stack.Children.Clear();

            ItemLegend leg = new ItemLegend();
            stack.Children.Add(leg);

            ItemControl wep, arm, item;

            foreach (Weapon w in weapons)
            {
                wep = new ItemControl(w);
                stack.Children.Add(wep);
            }

            foreach (Armour a in armours)
            {
                arm = new ItemControl(a);
                stack.Children.Add(arm);
            }

            foreach (Item i in items)
            {
                item = new ItemControl(i);
                stack.Children.Add(item);
            }

            UpdateCarryCapacity();
        }

        public void RemoveWeapon(Weapon w)
        {

            // Assuring there's no reference passed
            List<Weapon> newList = new List<Weapon>();

            foreach (Weapon weapon in weapons)
            {
                newList.Add(w);
            }

            // Searching for the weapon, possibly decrement quantity.
            foreach (Weapon weapon in newList)
            {
                if (weapon == w)
                {
                    if (weapon.GetQuantity() > 1)
                    {
                        weapon.DecrementQuantity();
                    }
                    else
                    {
                        weapons.Remove(weapon);
                    }
                }
            }

            UpdateInventory();
        }

        public void RemoveArmour(Armour a)
        {

            // Assuring there's no reference passed
            List<Armour> newList = new List<Armour>();

            foreach (Armour arm in armours)
            {
                newList.Add(arm);
            }

            // Searching for the weapon, possibly decrement quantity.
            foreach (Armour armour in newList)
            {
                if (armour == a)
                {
                    if (armour.GetQuantity() > 1)
                    {
                        armour.DecrementQuantity();
                    }
                    else
                    {
                        armours.Remove(armour);
                    }
                }
            }

            UpdateInventory();
            
        }

        public void RemoveItem(Item i)
        {

            // Assuring there's no reference passed
            List<Item> newList = new List<Item>();

            foreach (Item it in items)
            {
                newList.Add(it);
            }

            // Searching for the weapon, possibly decrement quantity.
            foreach (Item item in newList)
            {
                if (item == i)
                {
                    if (item.GetQuantity() > 1)
                    {
                        item.DecrementQuantity();
                    }
                    else
                    {
                        items.Remove(item);
                    }
                }
            }

            UpdateInventory();
        }

        public void AddWeapon(Weapon w)
        {
            bool duplicate = false;

            foreach (Weapon weapon in weapons)
            {
                if (weapon == w)
                {
                    weapon.IncrementQuantity();
                    duplicate = true;
                    break;
                }
            }

            if (!duplicate)
            {
                //Add the weapon to the inventory as a new weapon.
                weapons.Add(w);
            }

            UpdateInventory();
        }

        public void AddArmour(Armour a)
        {
            bool duplicate = false;

            foreach (Armour armour in armours)
            {
                if (armour == a)
                {
                    armour.IncrementQuantity();
                    duplicate = true;
                    break;
                }
            }

            if (!duplicate)
            {
                armours.Add(a);
            }

            UpdateInventory();
        }

        public void AddItem(Item i)
        {
            bool duplicate = false;

            foreach (Item item in items)
            {
                if (item == i)
                {
                    item.IncrementQuantity();
                    duplicate = true;
                    break;
                }
            }

            if (!duplicate)
            {
                items.Add(i);
            }

            UpdateInventory();
        }

        private void UpdateCarryCapacity()
        {
            // Put all items together for carry weight calculation
            allItems.Clear();

            foreach (Weapon w in weapons)
            {
                allItems.Add(w);
            }

            foreach (Armour a in armours)
            {
                allItems.Add(a);
            }

            foreach  (Item i in items)
            {
                allItems.Add(i);
            }

            totalItemWeight = 0;

            foreach (Item i in allItems)
            {
                string weight = i.GetWeight();
                string temp = string.Empty;
                double result;

                for (int j = 0; j < weight.Length; j++)
                {
                    if (double.TryParse(weight[j].ToString(), out result) || weight[j] == '.')
                    {
                        if (weight[j] == '.')
                            temp += ',';
                        else
                        {
                            temp += weight[j];
                        }

                    }
                    else
                    {
                        break;
                    }
                }

                if (temp != "")
                {
                    result = (Convert.ToDouble(temp) * i.GetQuantity());
                    totalItemWeight += result;
                }
            }
            lbCarry.Content = "Carry capacity: " + totalItemWeight.ToString() + " / " + c.CalcCarryWeight().ToString();
        }

        public void SetEquipedItems(List<Item> equipedItems)
        {
            this.equipedItems = equipedItems;
        }
    }
}
