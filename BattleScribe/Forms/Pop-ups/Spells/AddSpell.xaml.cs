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
using System.Windows.Shapes;

namespace BattleScribe.Forms.Pop_ups
{
    public partial class AddSpell : Window
    {
        private Character c;
        private DbHandler db;
        private List<Spell> spells;
        private Spell spell;
        private DetailScreen screen;

        public AddSpell(DetailScreen detailScreen)
        {
            InitializeComponent();

            db = new DbHandler();
            spells = new List<Spell>();
            screen = detailScreen;

            GetSpells();
        }

        public AddSpell(Character c, DetailScreen detailScreen)
        {
            InitializeComponent();

            this.c = c;
            db = new DbHandler();
            spells = new List<Spell>();
            screen = detailScreen;
            GetSpells();
        }

        private void GetSpells()
        {
            spells = db.GetSpells();

            foreach (Spell s in spells)
            {
                cbSpell.Items.Add(s);
            }
        }

        private void cbSpell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSpell.SelectedItem != null)
            {
                Spell temp = (Spell)cbSpell.SelectedItem;

                tbCast.Text = temp.GetCastTime();
                tbComponents.Text = temp.GetComponents();
                tbDuration.Text = temp.GetDuration();
                tbHigher.Text = temp.GetHigher();
                tbLevel.Text = temp.GetLevel().ToString();
                tbRange.Text = temp.GetRange();

                rtbDesc.Document.Blocks.Clear();
                rtbDesc.Document.Blocks.Add(new Paragraph(new Run(temp.GetDesc())));
                spell = temp;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BattleScribe.Controls.Spells.SpellPrepControl temp = new Controls.Spells.SpellPrepControl(spell);
            screen.panelSpells.Children.Add(temp);
            screen.spells.Add(spell);

            this.Close();

        }
    }
}
