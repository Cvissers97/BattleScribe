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
using BattleScribe.Classes;

namespace BattleScribe.Controls.Spells
{
    /// <summary>
    /// Interaction logic for SpellPrepControl.xaml
    /// </summary>
    public partial class SpellPrepControl : UserControl
    {
        Spell spell;
        public bool isSelected;
        public SpellPrepControl()
        {
            InitializeComponent();
        }

        public SpellPrepControl(Spell s)
        {
            spell = s;
            InitializeComponent();
            lblName.Content = s.GetName();
            lblLvl.Content = s.GetSchool();
            isSelected = false;

            if (s.GetPrepared())
            {
                isSelected = true;
                this.chkPrep.IsChecked = true;
            }

            if (s.GetLevel() == 0)
            {
                chkPrep.Visibility = Visibility.Hidden;
            }
        }

        private void UserControl_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            BattleScribe.Forms.Pop_ups.Spells.ViewSpell view = new Forms.Pop_ups.Spells.ViewSpell(spell.GetName(), spell.GetLevel().ToString(), spell.GetRange(), spell.GetComponents(), spell.GetDuration(), spell.GetCastTime(), spell.GetHigher(), spell.GetDesc());
            view.Show();
        }

        public bool GetSelected()
        {
            return chkPrep.IsChecked.Value;
        }

        public Spell GetSpell()
        {
            return this.spell;
        }

        public void SetSpellPrepared(bool isPrepared)
        {
            spell.SetPrepared(isPrepared);
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!isSelected)
            {
                this.Background = new SolidColorBrush(System.Windows.Media.Colors.Aquamarine);
                isSelected = true;
            }
            else
            {
                isSelected = false;
                this.Background = null;
            }
        }
    }
}
