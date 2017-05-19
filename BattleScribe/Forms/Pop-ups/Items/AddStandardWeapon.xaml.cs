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
    /// Interaction logic for AddStandardWeapon.xaml
    /// </summary>
    public partial class AddStandardWeapon : Window
    {
        private int characterId;
        private DetailScreen screen;

        public AddStandardWeapon()
        {
            InitializeComponent();
        }

        public AddStandardWeapon(int id)
        {
            InitializeComponent();

            this.characterId = id;
        }

        public AddStandardWeapon(DetailScreen screen)
        {
            InitializeComponent();
            this.screen = screen;
        }
    }
}
