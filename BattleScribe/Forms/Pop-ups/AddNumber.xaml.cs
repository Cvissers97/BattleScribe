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

namespace BattleScribe.Forms.Pop_ups
{
    /// <summary>
    /// Interaction logic for AddEXP.xaml
    /// </summary>
    public partial class AddNumber : Window
    {
        private DetailScreen detail;
        private PlayScreen play;
        private string setting;

        public AddNumber()
        {
            InitializeComponent();
            setting = "DEFAULT";
        }

        public AddNumber(DetailScreen detail, string setting)
        {
            InitializeComponent();
            this.detail = detail;

            // If EXP use "EXP"
            this.setting = setting;
        }

        public AddNumber(PlayScreen play, string setting)
        {
            InitializeComponent();
            this.play = play;

            // If healing use "HEAL"
            // If getting damage use "DAMAGE"
            // If casting at higher level, use "SPELL"
            this.setting = setting;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Execute();
        }

        private void tbAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbAmount.Text, @"^[-+]?[0-9]*\.?[0-9]+$"))
            {
                tbAmount.Text = string.Empty;
            }
        }

        private void tbAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Execute();
            }
        }

        private void Execute()
        {
            int amount = 0;

            if (tbAmount.Text != "")
            {
                amount = Convert.ToInt32(tbAmount.Text);
            }

            switch (setting)
            {
                default:
                    MessageBox.Show("Setting was not properly when creating constructing the AddNumber form.");
                    break;

                case "DEFAULT":
                    MessageBox.Show("Setting was not properly when creating constructing the AddNumber form.");
                    break;

                case "EXP":
                    play.expToAdd += amount;
                    break;

                case "HEAL":
                    if ((play.GetCharacter().GetCurrentHealth() + amount) > play.GetCharacter().GetMaxHealth())
                    {
                        play.GetCharacter().SetCurrentHealth(play.GetCharacter().GetMaxHealth());
                    }
                    else
                    {
                        play.GetCharacter().SetCurrentHealth(play.GetCharacter().GetCurrentHealth() + amount);
                    }
                    play.UpdateHealth();
                    break;

                case "DAMAGE":
                    if ((play.GetCharacter().GetCurrentHealth() - amount) < 0)
                    {
                        play.GetCharacter().SetCurrentHealth(0);
                    }
                    else
                    {
                        play.GetCharacter().SetCurrentHealth(play.GetCharacter().GetCurrentHealth() - amount);
                    }
                    play.UpdateHealth();
                    break;

                case "SPELL":
                    if (amount < 10 && amount > 0)
                    {
                        try
                        {
                            byte temp = Convert.ToByte(amount);
                            play.CastAtHigherLevel(temp);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Invalid input.");
                        }
                    }
                    break;
            }
            this.Close();
        }
    }
}
