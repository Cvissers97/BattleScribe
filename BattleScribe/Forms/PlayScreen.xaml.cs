using BattleScribe.Classes;
using BattleScribe.Classes.Items;
using BattleScribe.Controls;
using BattleScribe.Controls.Items;
using BattleScribe.Forms;
using BattleScribe.Forms.Pop_ups.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BattleScribe.Forms
{
    public partial class PlayScreen : Window
    {
        private Character c;

        public PlayScreen()
        {
            InitializeComponent();

            UpdateInventory();
        }

        public PlayScreen(Character c)
        {
            InitializeComponent();

            this.c = c;
        }

        private void UpdateInventory()
        {
            stackInventory.Children.Clear();
            ItemLegend leg = new ItemLegend();
            stackInventory.Children.Add(leg);
            //Read out all items in the character's inventory (Armour, Weapon, Item)
            //Turn all of them into stackpanels

            //Temp character for inventory testing. Write proper getters/setters for inventory later
            c = new Character(13);
            Weapon sword = new Weapon(30, "Flamesword", "Hot", 1, 4, "Weapon", true, true, 10.5, "DEX", 10, "Slashing", "Fire");
            c.AddWeapon(sword);
            Item ring = new Item(20, "Ring", "Fancy ring", "Jewelry", false, true, 0.5);
            c.AddItem(ring);
            Armour chainmail = new Armour(2, "Chainmail", "Mail of chains", "Armour", true, true, 35, true, 10, 3, "STR");
            c.AddArmour(chainmail);

            ItemControl temp;

            foreach (Weapon w in c.GetAllWeapons())
            {
                temp = new ItemControl(w.GetID());
                temp.lbName.Content = w.GetName();
                temp.lbType.Content = w.GetType();
                temp.lbProficiency.Content = w.GetProficient();
                temp.lbValue.Content = w.GetValue();
                temp.lbWeight.Content = w.GetWeight();
                temp.lbAttune.Content = w.GetAttunement();
                stackInventory.Children.Add(temp);
            }

            foreach (Item i in c.GetAllItems())
            {
                temp = new ItemControl(i.GetID());
                temp.lbName.Content = i.GetName();
                temp.lbType.Content = i.GetItemType();
                temp.lbProficiency.Content = i.GetProficient();
                temp.lbValue.Content = i.GetValue();
                temp.lbWeight.Content = i.GetWeight();
                temp.lbAttune.Content = i.GetAttunement();
                stackInventory.Children.Add(temp);
            }

            foreach (Armour a in c.GetAllArmours())
            {
                temp = new ItemControl(a.GetID());
                temp.lbName.Content = a.GetName();
                temp.lbType.Content = a.GetItemType();
                temp.lbProficiency.Content = a.GetProficient();
                temp.lbValue.Content = a.GetValue();
                temp.lbWeight.Content = a.GetWeight();
                temp.lbAttune.Content = a.GetAttunement();
                stackInventory.Children.Add(temp);
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            ItemChoice i = new ItemChoice(c.GetID());
            i.Show();
        }
    }
}
