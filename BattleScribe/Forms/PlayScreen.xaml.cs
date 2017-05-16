using BattleScribe.Classes;
using BattleScribe.Controls;
using BattleScribe.Forms;
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

namespace BattleScribe.Forms
{
    public partial class PlayScreen : Window
    {
        private Character c;

        public PlayScreen()
        {
            InitializeComponent();
        }

        public PlayScreen(Character c)
        {
            InitializeComponent();

            this.c = c;
        }

        private void UpdateInventory()
        {
            //Read out all items in the character's inventory (Armour, Weapon, Item)
            //Turn all of them into stackpanels


        }
    }
}
