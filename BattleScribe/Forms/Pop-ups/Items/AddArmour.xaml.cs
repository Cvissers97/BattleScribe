using BattleScribe.Classes;
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
using BattleScribe.Classes.Items;

namespace BattleScribe.Forms.Pop_ups.Items
{
    /// <summary>
    /// Interaction logic for AddArmour.xaml
    /// </summary>
    public partial class AddArmour : Window
    {
        private int characterId;
        private InventoryManager inventory;
        private Armour armour;
        private DbHandler db;
        string minusRegex = @"^[-+]?[0-9]*\.?[0-9]+$";

        public AddArmour()
        {
            InitializeComponent();
        }

        public AddArmour(int id)
        {
            InitializeComponent();

            this.characterId = id;
        }

        public AddArmour(InventoryManager inventory)
        {
            InitializeComponent();
            this.inventory = inventory;

            cbMod.Items.Add("STR");
            cbMod.Items.Add("DEX");
            cbMod.Items.Add("CON");
            cbMod.Items.Add("INT");
            cbMod.Items.Add("WIS");
            cbMod.Items.Add("CHA");
            cbMod.Items.Add("NA");

            cbType.Items.Add("Light");
            cbType.Items.Add("Medium");
            cbType.Items.Add("Heavy");
            cbType.Items.Add("Shield");

            db = new DbHandler();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbArmourBonus.Text, minusRegex))
            {
                armour = new Armour(tbName.Text, (new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text), false, Convert.ToInt32(tbArmourBonus.Text), Convert.ToInt32(tbBaseArmour.Text), (string)cbMod.SelectedItem, Convert.ToInt32(tbStrReq.Text), (bool)chkStealth.IsChecked, tbWeight.Text, "0", (string)cbType.SelectedItem, (bool)chkAttune.IsChecked);
                int newItemId = db.InsertNewArmour(armour);
                db.InsertInItemTable(newItemId, 2);
                MessageBox.Show(armour.GetName() + " added to the collection.");
            }
            else
            {
                MessageBox.Show("Incorrect armour bonus. (Can be negative.)");
            }
        }

        private void tbWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbWeight.Text, "^[0-9]*$"))
            {
                tbWeight.Text = string.Empty;
            }
        }

        private void tbStrReq_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbStrReq.Text, "^[0-9]*$"))
            {
                tbStrReq.Text = string.Empty;
            }
        }

        private void tbArmourBonus_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void tbBaseArmour_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbBaseArmour.Text, "^[0-9]*$"))
            {
                tbBaseArmour.Text = string.Empty;
            }
        }
    }
}
