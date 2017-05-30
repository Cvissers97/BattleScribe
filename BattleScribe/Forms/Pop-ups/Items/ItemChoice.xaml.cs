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

namespace BattleScribe.Forms.Pop_ups.Items
{
    /// <summary>
    /// Interaction logic for ItemChoice.xaml
    /// </summary>
    public partial class ItemChoice : Window
    {
        private int characterId;
        private InventoryManager inventory;

        public ItemChoice()
        {
            InitializeComponent();
        }

        public ItemChoice(int characterId)
        {
            InitializeComponent();
            this.characterId = characterId;
        }

        public ItemChoice(InventoryManager inventory)
        {
            InitializeComponent();
            this.inventory = inventory;
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
            AddStandardItem a = new AddStandardItem(inventory);
            a.Show();
            this.Close();
        }

        private void btnWeapon_Click(object sender, RoutedEventArgs e)
        {
            AddStandardWeapon a = new AddStandardWeapon(inventory);
            a.Show();
            this.Close();
        }

        private void btnArmour_Click(object sender, RoutedEventArgs e)
        {
            AddStandardArmour a = new AddStandardArmour(inventory);
            a.Show();
            this.Close();
        }

        private void btnCustItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem a = new AddItem(inventory);
            a.Show();
            this.Close();
        }

        private void btnCustWeapon_Click(object sender, RoutedEventArgs e)
        {
            AddWeapon a = new AddWeapon(inventory);
            a.Show();
            this.Close();
        }

        private void btnCustArmour_Click(object sender, RoutedEventArgs e)
        {
            AddArmour a = new AddArmour(inventory);
            a.Show();
            this.Close();
        }
    }
}
