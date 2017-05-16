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
    /// Interaction logic for AddStandardArmour.xaml
    /// </summary>
    public partial class AddStandardArmour : Window
    {
        private int characterId;

        public AddStandardArmour()
        {
            InitializeComponent();
        }

        public AddStandardArmour(int id)
        {
            InitializeComponent();

            this.characterId = id;
        }
    }
}
