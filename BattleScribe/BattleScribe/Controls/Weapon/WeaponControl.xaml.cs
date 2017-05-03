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

namespace BattleScribe.Classes
{
    /// <summary>
    /// Interaction logic for Test1.xaml
    /// </summary>
    public partial class WeaponControl : UserControl
    {
        public WeaponControl()
        {
            InitializeComponent();
        }


        private void WepNameBoxLeftClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(wepNameBox.Text);
        }

        private void WepToHitBoxLeftClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(wepToHitBox.Text);
        }

        private void WepDmgBoxLeftClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(wepDmgBox.Text);
        }
    }
}
