using BattleScribe.Classes;
using BattleScribe.Classes.Items;
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

namespace BattleScribe.Forms.Pop_ups.Items
{
    public partial class AddItem : Window
    {
        private int characterId;
        private InventoryManager inventory;
        private DbHandler db;
        private Item item;

        public AddItem()
        {
            InitializeComponent();
        }

        public AddItem(int id)
        {
            InitializeComponent();

            this.characterId = id;
        }

        public AddItem(InventoryManager inventory)
        {
            InitializeComponent();
            this.inventory = inventory;
            db = new DbHandler();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            item = new Item(tbName.Text, (new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text), tbType.Text, tbWeight.Text, 1);
            item.SetAttunement((bool)chkAttune.IsChecked);
            item.SetProficient((bool)chkProf.IsChecked);
            int itemId = db.InsertNewItem(item);
            try
            {
                db.InsertInItemTable(itemId, 3);
                MessageBox.Show(item.GetName() + " added with succes.");
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please try again.");
            }

        }
    }
}
