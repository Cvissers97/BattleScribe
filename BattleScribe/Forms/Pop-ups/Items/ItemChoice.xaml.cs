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
        private DetailScreen screen;

        public ItemChoice()
        {
            InitializeComponent();
        }

        public ItemChoice(int characterId)
        {
            InitializeComponent();
            this.characterId = characterId;
        }
        public ItemChoice(DetailScreen screen)
        {
            InitializeComponent();
            this.screen = screen;
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
            AddStandardItem a = new AddStandardItem(screen);
            a.Show();
            this.Close();
        }

        private void btnWeapon_Click(object sender, RoutedEventArgs e)
        {
            AddStandardWeapon a = new AddStandardWeapon(screen);
            a.Show();
            this.Close();
        }

        private void btnArmour_Click(object sender, RoutedEventArgs e)
        {
            AddStandardArmour a = new AddStandardArmour(screen);
            a.Show();
            this.Close();
        }

        private void btnCustItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem a = new AddItem(screen);
            a.Show();
            this.Close();
        }

        private void btnCustWeapon_Click(object sender, RoutedEventArgs e)
        {
            AddWeapon a = new AddWeapon(screen);
            a.Show();
            this.Close();
        }

        private void btnCustArmour_Click(object sender, RoutedEventArgs e)
        {
            AddArmour a = new AddArmour(screen);
            a.Show();
            this.Close();
        }
    }
}
