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


            BattleScribe.Classes.DbHandler db = new Classes.DbHandler();

            WeaponLegend legend = new WeaponLegend();
            slackPanel.Children.Add(legend);

            List<Spell> s = db.GetSpells();

            foreach (Spell sp in s)
            {
                WeaponControl wepCont = new WeaponControl();
                wepCont.wepNameBox.Text = sp.GetName();
                wepCont.wepToHitBox.Text = sp.GetDesc();
                slackPanel.Children.Add(wepCont);
            }
        }
    }
}
