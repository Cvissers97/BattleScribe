using BattleScribe.Forms.Pop_ups;
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

namespace BattleScribe.Controls.Skills
{
    /// <summary>
    /// Interaction logic for SkillControl.xaml
    /// </summary>
    public partial class SkillControl : UserControl
    {
        int mod;
        private RollSkillScreen screen;

        public SkillControl()
        {
            InitializeComponent();
        }

        public SkillControl(int mod, RollSkillScreen screen)
        {
            InitializeComponent();
            this.mod = mod;
            this.screen = screen;
            lbMod.Content = mod;
        }

        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            screen.Roll(mod);
        }
    }
}
