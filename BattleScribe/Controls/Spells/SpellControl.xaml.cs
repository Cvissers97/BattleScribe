using BattleScribe.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleScribe.Controls.Spells
{
    /// <summary>
    /// Interaction logic for SpellControl.xaml
    /// </summary>
    public partial class SpellControl : UserControl
    {
        Spell spell;
        PlayScreen play;
        private Brush standardBrush;

        public SpellControl()
        {
            InitializeComponent();
        }

        public SpellControl(Spell spell, PlayScreen play)
        {
            InitializeComponent();
            standardBrush = this.Background;
            this.spell = spell;
            this.play = play;
        }

        private void UserControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            play.ChooseSpell(spell);
        }

        public void Highlight(bool target)
        {
            if (target)
            {
                this.Background = new SolidColorBrush(System.Windows.Media.Colors.Indigo);
            }
            else
            {
                this.Background = standardBrush;
            }
        }

        public Spell GetSpell()
        {
            return spell;
        }

        private void UserControl_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            BattleScribe.Forms.Pop_ups.Spells.ViewSpell screen = new Forms.Pop_ups.Spells.ViewSpell(spell.GetName(), spell.GetLevel().ToString(), spell.GetRange(), spell.GetComponents(), spell.GetDuration(), spell.GetCastTime(), spell.GetHigher(), spell.GetDesc());
            screen.Show();
        }
    }
}
