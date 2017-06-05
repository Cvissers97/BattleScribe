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
            armour = new Armour(tbName.Text, (new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text), false, Convert.ToInt32(tbArmourBonus.Text), Convert.ToInt32(tbBaseArmour.Text), (string)cbMod.SelectedItem, Convert.ToInt32(tbStrReq.Text), (bool)chkStealth.IsChecked, tbWeight.Text, "0", (string)cbType.SelectedItem, (bool)chkAttune.IsChecked);
            int newItemId = db.InsertNewArmour(armour);
            db.InsertInItemTable(newItemId, 2);
        }
    }
}
