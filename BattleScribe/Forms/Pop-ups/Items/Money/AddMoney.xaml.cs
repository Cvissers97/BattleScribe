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

namespace BattleScribe.Forms.Pop_ups.Items.Money
{
    /// <summary>
    /// Interaction logic for AddMoney.xaml
    /// </summary>
    public partial class AddMoney : Window
    {
        public AddMoney()
        {
            InitializeComponent();
        }

        private void tbPlat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbPlat.Text, "^[0-9]*$"))
            {
                tbPlat.Text = string.Empty;
            }
        }

        private void tbGold_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbGold.Text, "^[0-9]*$"))
            {
                tbGold.Text = string.Empty;
            }
        }

        private void tbSilv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbSilv.Text, "^[0-9]*$"))
            {
                tbSilv.Text = string.Empty;
            }
        }

        private void tbCop_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbCop.Text, "^[0-9]*$"))
            {
                tbCop.Text = string.Empty;
            }
        }
    }
}
