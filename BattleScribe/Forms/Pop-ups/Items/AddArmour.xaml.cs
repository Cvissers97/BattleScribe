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
    /// Interaction logic for AddArmour.xaml
    /// </summary>
    public partial class AddArmour : Window
    {
        private int characterId;
        private InventoryManager inventory;

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
        }
    }
}
