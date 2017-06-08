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
using BattleScribe.Classes;
using BattleScribe.Classes.Items;

namespace BattleScribe.Forms.Pop_ups.Items
{
    /// <summary>
    /// Interaction logic for AddWeapon.xaml
    /// </summary>
    public partial class AddWeapon : Window
    {
        private int characterId;
        private List<int> diceSides;
        private List<string> modifiers;
        private InventoryManager inventory;
        private DbHandler dbhandler;
       //private Weapon weapon;

        public AddWeapon()
        {
            InitializeComponent();
            diceSides = new List<int>();
            modifiers = new List<string>();

            // Adding all the dicesides
            diceSides.Add(0);
            diceSides.Add(2);
            diceSides.Add(4);
            diceSides.Add(6);
            diceSides.Add(8);
            diceSides.Add(10);
            diceSides.Add(12);
            diceSides.Add(20);

            foreach (int i in diceSides)
            {
                cbDiceSides.Items.Add(i);
                cbDiceSides2.Items.Add(i);
            }

            // Adding all modifiers
            modifiers.Add("STR");
            modifiers.Add("DEX");
            modifiers.Add("CON");
            modifiers.Add("INT");
            modifiers.Add("WIS");
            modifiers.Add("CHA");

            foreach (string s in modifiers)
            {
                cbModifier.Items.Add(s);
            }
        }

        public AddWeapon(int id)
        {
            InitializeComponent();

            this.characterId = id;
            diceSides = new List<int>();
            modifiers = new List<string>();

            // Adding all the dicesides
            diceSides.Add(2);
            diceSides.Add(4);
            diceSides.Add(6);
            diceSides.Add(8);
            diceSides.Add(10);
            diceSides.Add(12);
            diceSides.Add(20);

            foreach (int i in diceSides)
            {
                cbDiceSides.Items.Add(i);
            }

            // Adding all modifiers
            modifiers.Add("STR");
            modifiers.Add("DEX");
            modifiers.Add("CON");
            modifiers.Add("INT");
            modifiers.Add("WIS");
            modifiers.Add("CHA");

            foreach (string s in modifiers)
            {
                cbModifier.Items.Add(s);
            }

            MessageBox.Show("Adding items for character ID: " + characterId);
        }

        public AddWeapon(InventoryManager inventory)
        {
            this.inventory = inventory;
            InitializeComponent();
            diceSides = new List<int>();
            modifiers = new List<string>();
            dbhandler = new DbHandler();

            // Adding all the dicesides
            diceSides.Add(0);
            diceSides.Add(2);
            diceSides.Add(4);
            diceSides.Add(6);
            diceSides.Add(8);
            diceSides.Add(10);
            diceSides.Add(12);
            diceSides.Add(20);

            foreach (int i in diceSides)
            {
                cbDiceSides.Items.Add(i);
                cbDiceSides2.Items.Add(i);
            }

            // Adding all modifiers
            modifiers.Add("STR");
            modifiers.Add("DEX");
            modifiers.Add("CON");
            modifiers.Add("INT");
            modifiers.Add("WIS");
            modifiers.Add("CHA");
            modifiers.Add("FIN");
                
            foreach (string s in modifiers)
            {
                cbModifier.Items.Add(s);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string damage1 = tbDiceAmount.Text + 'd' + cbDiceSides.SelectedItem;
                string damage2 = tbDiceAmount2.Text + 'd' + cbDiceSides2.SelectedItem;
                Weapon w = new Weapon(tbName.Text, damage1, damage2, tbAttackType.Text, tbBonusType.Text, "-", (new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text), tbBonusType3.Text, cbModifier.SelectedItem.ToString(), Convert.ToInt32(tbBonusDamage.Text));
                w.SetWeight(tbWeight.Text);
                w.SetAttunement((bool)chkAttune.IsChecked);
                w.SetProficient((bool)chkProf.IsChecked);
                w.SetValue("1");
                w.SetItemType(tbType.Text);
                int itemId = dbhandler.InsertNewWeapon(w);
                dbhandler.InsertInItemTable(itemId, 1);
                MessageBox.Show(w.GetName() + " added to the collection.");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
