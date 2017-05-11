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

        public AddSpell()
        {
            InitializeComponent();
        }

        public AddSpell(Character c)
        {
            InitializeComponent();

            this.c = c;
            db = new DbHandler();
            spells = new List<Spell>();

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
                
            }
        }
    }
}
