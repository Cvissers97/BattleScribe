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
    /// Interaction logic for AddHealth.xaml
    /// </summary>
    public partial class AddHealth : Window
    {
        private Random rand;
        private DetailScreen detail;

        private int currentHP;
        private int conModifier;
        private int newHP;
        private int diceSides;
        private string characterClass;

        public AddHealth()
        {
            InitializeComponent();
        }

        public AddHealth(int CurHP, int conMod, string characterClass, DetailScreen detail)
        {
            InitializeComponent();

            this.detail = detail;
            this.currentHP = CurHP;
            this.newHP = 0;
            this.conModifier = conMod;
            this.characterClass = characterClass;

            lbCurHP.Content = "Current HP: " + (currentHP + newHP);
            
            //Fill in the other classes later
            switch (characterClass)
            {
                case "Wizard":
                    diceSides = 6;
                    break;
                    
                case "Barbarian":
                    diceSides = 12;
                    break;
            }
        }

        private void btnUpHealth_Click(object sender, RoutedEventArgs e)
        {
            newHP += (diceSides / 2 + 1) + conModifier;
            lbCurHP.Content = "Current HP: " + (currentHP + newHP);
        }

        private void btnRollHealth_Click(object sender, RoutedEventArgs e)
        {
            rand = new Random();
            newHP += (rand.Next(1, 6)) + conModifier;
            lbCurHP.Content = "Current HP: " + (currentHP + newHP);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show(currentHP.ToString() + " " + newHP.ToString());
            detail.SetNewHealth(currentHP + newHP);
        }
    }
}
