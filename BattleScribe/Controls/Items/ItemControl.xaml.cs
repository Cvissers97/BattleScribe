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

namespace BattleScribe.Controls.Items
{
    /// <summary>
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {
        private int id;

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
            lbValue.Content = i.GetValue();
            lbWeight.Content = i.GetWeight();
            lbAttune.Content = "-";
            lbProficiency.Content = "-";
        }
    }
}
