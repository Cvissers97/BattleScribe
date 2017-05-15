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

namespace BattleScribe.Forms.Pop_ups.Spells
{
    /// <summary>
    /// Interaction logic for ViewSpell.xaml
    /// </summary>
    public partial class ViewSpell : Window
    {
        public ViewSpell()
        {
            InitializeComponent();
        }

        public ViewSpell(string name, string level, string range, string components, string duration, string castTime, string higherLevels, string desc)
        {
            InitializeComponent();
            this.tbName.Text = name;
            this.tbLevel.Text = level;
            this.tbRange.Text = range;
            this.tbComponents.Text = components;
            this.tbDuration.Text = duration;
            this.tbCast.Text = castTime;
            this.tbHigher.Text = higherLevels;
            this.rtbDesc.AppendText(desc);
        }
    }
}
