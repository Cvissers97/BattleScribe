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

namespace BattleScribe.Forms.Pop_ups.Items.Money
{
    public partial class AddMoney : Window
    {
        MoneyManager money;

        public AddMoney()
        {
            InitializeComponent();
        }

        public AddMoney(MoneyManager money)
        {
            InitializeComponent();

            this.money = money;
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int copper = 0;
            int silver = 0;
            int gold = 0;
            int platinum = 0;

            try
            {
                if (tbCop.Text != "")
                {
                    copper = Convert.ToInt32(tbCop.Text);
                }
                if (tbSilv.Text != "")
                {
                    silver = Convert.ToInt32(tbSilv.Text);
                }
                if (tbGold.Text != "")
                {
                    gold = Convert.ToInt32(tbGold.Text);
                }
                if (tbPlat.Text != "")
                {
                    platinum = Convert.ToInt32(tbPlat.Text);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Invalid input.");
            }

            money.ReceiveMoney(copper, silver, gold, platinum);
        }
    }
}
