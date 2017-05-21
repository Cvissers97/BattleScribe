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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BattleScribe.Classes.Items;
using BattleScribe.Forms.Pop_ups.Items;

namespace BattleScribe.Controls.Items
{
    /// <summary>
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {
        private int id;
        private Item item;

        public ItemControl()
        {
            InitializeComponent();
        }

        public ItemControl(int id)
        {
            InitializeComponent();

            this.id = id;
        }

        public ItemControl(Item i)
        {
            InitializeComponent();
            lbName.Content = i.GetName();
            lbType.Content = "Adv. gear";
            lbWeight.Content = i.GetWeight();
            lbAttune.Content = "-";
            lbProficiency.Content = "-";
            lbQuantity.Content = i.GetQuantity();
            this.item = i;
        }

        public ItemControl(Weapon w)
        {
            InitializeComponent();
            lbName.Content = w.GetName();
            lbType.Content = w.GetItemType();
            lbWeight.Content = w.GetWeight();
            lbAttune.Content = w.GetAttunement();
            lbProficiency.Content = "WIP";
            lbQuantity.Content = w.GetQuantity();
            this.item = w;
        }

        public ItemControl(Armour a)
        {
            InitializeComponent();
            lbName.Content = a.GetName();
            lbType.Content = a.GetItemType();
            lbWeight.Content = a.GetWeight();
            lbAttune.Content = a.GetAttunement();
            lbProficiency.Content = "WIP";
            lbQuantity.Content = a.GetQuantity();
            this.item = a;
        }

        private void UserControl_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewItem temp = new ViewItem(item);
            temp.Show();
        }
    }
}
