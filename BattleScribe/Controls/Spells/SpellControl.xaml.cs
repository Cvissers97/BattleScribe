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

        public SpellControl()
        {
            InitializeComponent();
        }

        public SpellControl(Spell spell)
        {
            InitializeComponent();
            this.spell = spell;
        }
    }
}
