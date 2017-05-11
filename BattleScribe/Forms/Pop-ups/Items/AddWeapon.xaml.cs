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
    /// Interaction logic for AddWeapon.xaml
    /// </summary>
    public partial class AddWeapon : Window
    {
        private List<int> diceSides;
        private List<string> modifiers;

        public AddWeapon()
        {
            InitializeComponent();
            diceSides = new List<int>();

            // Adding all the dicesides
            diceSides.Add(2);
            diceSides.Add(4);
            diceSides.Add(6);
            diceSides.Add(8);
            diceSides.Add(10);
            diceSides.Add(12);
            diceSides.Add(20);

            foreach (int i in diceSides)
            {
                cbDiceSides.Items.Add(i);
            }

            // Adding all modifiers
            modifiers.Add("STR");
            modifiers.Add("DEX");
            modifiers.Add("CON");
            modifiers.Add("INT");
            modifiers.Add("WIS");
            modifiers.Add("CHA");

            foreach (string s in modifiers)
            {
                cbModifier.Items.Add(s);
            }
        }
    }
}
