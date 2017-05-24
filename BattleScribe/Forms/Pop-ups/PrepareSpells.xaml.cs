using BattleScribe.Classes;
using BattleScribe.Controls.Spells;
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
    public partial class PrepareSpells : Window
    {
        private DbHandler db;
        private PlayScreen play;
        private Character c;
        private List<Spell> knownSpells;
        private List<int> spellPrepIds;

        public PrepareSpells()
        {
            InitializeComponent();
        }

        public PrepareSpells(PlayScreen playScreen, Character character)
        {
            InitializeComponent();

            spellPrepIds = new List<int>();
            db = new DbHandler();
            this.play = playScreen;
            this.c = character;

            knownSpells = c.GetKnownSpells();
            SpellPrepControl prep;

            foreach (Spell s in knownSpells)
            {
                // Not adding cantrips, for they are always prepared.
                if (s.GetLevel() > 0)
                {
                    prep = new SpellPrepControl(s);
                    stackSpells.Children.Add(prep);
                }
            }

            int totalSpells = c.GetModifier(c.GetSpellMod()) + c.GetLevel();

            if (totalSpells < 1)
            {
                totalSpells = 1;
            }

            lbPrep.Content = "Preparable Spells: " + totalSpells;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            foreach (SpellPrepControl prep in stackSpells.Children)
            {
                if (prep.GetSelected())
                {
                    Spell spell = prep.GetSpell();
                    spellPrepIds.Add(Convert.ToInt32(spell.GetId()));
                }
            }

            if (spellPrepIds.Count() > 0)
            {
                db.PrepareSpells(spellPrepIds, c.GetID());
                play.UpdateSpells();
            }
            this.Close();
        }
    }
}
