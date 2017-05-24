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

namespace BattleScribe.Classes
{
    public class InventoryManager
    {
        public Character c;
        private List<Item> items;
        private List<Weapon> weapons;
        private List<Armour> armour;
        private StackPanel stack;

        public InventoryManager(Character c, StackPanel stack)
        {
            this.c = c;
            this.stack = stack;
        }

        private void UpdateInventory()
        {
 
        }

        public void AddWeapon(Weapon w)
        {
 
        }

        public void AddArmour(Armour w)
        {
 
        }

        public void AddItem(Item i)
        {
 
        }

        private void SaveInventory()
        {
 
        }



    }
}
