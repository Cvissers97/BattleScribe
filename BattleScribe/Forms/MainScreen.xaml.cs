using System;
using BattleScribe.Classes;
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
using BattleScribe.Classes.Items;
using BattleScribe.Controls;

namespace BattleScribe.Forms
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Window
    {
        public MainScreen()
        {
            InitializeComponent();

            List<Weapon> weps = new List<Weapon>();
            weps.Add(new Weapon("Coolwep", "Coolwep", 1, 6, "Coolwep", true, true, 100, "Coolwep", 1, "Coolwep", "Coolwep"));

            trollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            WeaponLegend legend = new WeaponLegend();
            slackPanel.Children.Add(legend);

            foreach (Weapon w in weps)
            {
                WeaponControl wepCont = new WeaponControl();
                wepCont.wepNameBox.Text = w.GetName();
                wepCont.wepToHitBox.Text = "+ 7";
                wepCont.wepDmgBox.Text = w.GetDiceAmount() + "d" + w.GetDiceSides() + " " + w.GetBaseDamageType() + " + " + w.GetBonusDamage() + " " + w.GetBonusDamageType();
                slackPanel.Children.Add(wepCont);
            }
        }
    }
}
