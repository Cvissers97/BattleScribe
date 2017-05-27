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

namespace BattleScribe.Forms.Pop_ups
{
    /// <summary>
    /// Interaction logic for CustomAttack.xaml
    /// </summary>
    public partial class CustomAttack : Window
    {
        private Character c;
        private LogHandler log;

        private int amount1, amount2, sides1, sides2, toHit, bonus;

        public CustomAttack()
        {
            InitializeComponent();
        }

        public CustomAttack(Character c, PlayScreen play)
        {
            InitializeComponent();

            List<int> diceSides = new List<int>();

            diceSides.Add(0);
            diceSides.Add(4);
            diceSides.Add(6);
            diceSides.Add(8);
            diceSides.Add(10);
            diceSides.Add(12);
            diceSides.Add(20);

            foreach (int i in diceSides)
            {
                cbDiceSides.Items.Add(i);
                cbDiceSides2.Items.Add(i);
            }

            this.c = c;

            tbDiceAmount.Text = c.lastDiceAmount.ToString() ?? string.Empty;
            tbDiceAmount2.Text = c.lastDiceAmount2.ToString() ?? string.Empty;
            cbDiceSides.Text = c.lastDiceSide.ToString() ?? string.Empty;
            cbDiceSides2.Text = c.lastDiceSide2.ToString() ?? string.Empty;
            tbToHit.Text = c.lastToHit.ToString() ?? string.Empty;
            tbBonus.Text = c.lastBonus.ToString();

            log = play.log;
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            bool secondDice = false;
            bonus = 0;

            if (chkProf.IsChecked.Value)
            {
                toHit += c.GetProfiencyBonus();
            }

            try
            {
                amount1 = Convert.ToInt32(tbDiceAmount.Text);

                if (tbDiceAmount2.Text != "" && tbDiceAmount2.Text != "0")
                {
                    amount2 = Convert.ToInt32(tbDiceAmount2.Text);
                    secondDice = true;
                }

                sides1 = (int)cbDiceSides.SelectedItem;

                if (secondDice)
                {
                    sides2 = (int)cbDiceSides2.SelectedItem;
                }

                toHit = Convert.ToInt32(tbToHit.Text);

                if (tbBonus.Text != "")
                {
                    bonus = Convert.ToInt32(tbBonus.Text);
                }

                int result = DiceThrower.ThrowDice(0, 20, toHit);
                log.Write("To Hit: " + result);

                result = DiceThrower.ThrowDice(amount1 - 1, sides1, 0);
                
                if (secondDice)
                {
                    if ((int)cbDiceSides2.SelectedItem != 0)
                    {
                        result += DiceThrower.ThrowDice(amount2, sides2, 0);
                    }
                }

                result += bonus;

                if (amount1 == 0)
                {
                    log.Write("Damage: Please use the first die!");
                }
                else
                {
                    log.Write("Damage: " + result);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Invalid Input: " + error.ToString());
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (tbDiceAmount.Text != "")
                {
                    c.lastDiceAmount = Convert.ToInt32(tbDiceAmount.Text);
                }

                if (tbDiceAmount2.Text != "")
                {
                    c.lastDiceAmount2 = Convert.ToInt32(tbDiceAmount2.Text);
                }

                if (tbToHit.Text != "")
                {
                    c.lastToHit = Convert.ToInt32(tbToHit.Text);
                }

                if (tbBonus.Text != "")
                {
                    c.lastBonus = Convert.ToInt32(tbBonus.Text);
                }

                c.lastDiceSide = (int)cbDiceSides.SelectedItem;
                c.lastDiceSide2 = (int)cbDiceSides2.SelectedItem;

            }
            catch (Exception)
            {
                MessageBox.Show("Please only put in numbers.");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbDiceAmount.Text = string.Empty;
            tbDiceAmount2.Text = string.Empty;
            cbDiceSides.Text = string.Empty;
            cbDiceSides2.Text = string.Empty;
            tbToHit.Text = string.Empty;
            tbBonus.Text = string.Empty;
        }
    }
}
