using BattleScribe.Classes;
using BattleScribe.Classes.Items;
using BattleScribe.Controls;
using BattleScribe.Controls.Feats;
using BattleScribe.Controls.Features;
using BattleScribe.Controls.Items;
using BattleScribe.Controls.Spells;
using BattleScribe.Forms;
using BattleScribe.Forms.Pop_ups;
using BattleScribe.Forms.Pop_ups.Items;
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

namespace BattleScribe.Forms
{
    public partial class PlayScreen : Window
    {
        private Character c;
        public LogHandler log;
        private DbHandler db;
        private Image imgTempDat;
        private List<Feature> features;
        private List<Feat> feats;
        private List<CharacterClass> cClass;
        private Spell chosenSpell;
        byte lifeThrow;
        byte deathThrow;
        int spellMod;
        int spellDc;

        public PlayScreen()
        {
            InitializeComponent();
            InitialiseBase();
        }

        public PlayScreen(Character c)
        {
            InitializeComponent();
            this.c = c;
            InitialiseBase();
        }

        private void InitialiseBase()
        {
            imgTempDat = new Image();
            imgTempDat.Source = imgInsp.Source;
            db = new DbHandler();

            lifeThrow = 0;
            deathThrow = 0;

            //UpdateInventory();
            UpdateInspiration();
            UpdateHealth();
            UpdateStats();
            UpdateFeatures();
            UpdateFeats();
            UpdateDeath();
            UpdateSpells();
            UpdateSavingThrows();
            UpdateTitle();
            UpdateButtons();

            log = new LogHandler(listAction);
        }

        private void UpdateButtons()
        {

        }

        private void UpdateTitle()
        {
            cClass = db.GetClasses();
            string _class = "CLASS";

            foreach (CharacterClass cl in cClass)
            {
                if (cl.GetId() == c.GetClass())
                {
                    _class = cl.GetName();
                    break;
                }
            }

            this.Title = c.GetName() + ", " + "level " + c.GetLevel() + " " + _class;
        }

        private void UpdateSavingThrows()
        {
            string[] throws = db.GetSavingThrowByClass(c.GetClass());

            c.SetSavingThrows(throws[0], throws[1]);
        }

        public void UpdateSpells()
        {
            spellMod = 0;
            spellDc = 0;

            panelSpells.Children.Clear();

            //SpellLegend leg = new SpellLegend();
            //panelSpells.Children.Add(leg);

            List<Spell> spells = db.GetSpellsByCharId(c.GetID());
            SpellControl spell;

            foreach (Spell s in spells)
            {
                if (s.GetLevel() == 0)
                {
                    s.SetPrepared(true);
                }
                if (s.GetPrepared())
                {
                    spell = new SpellControl(s, this);
                    spell.lbName.Content = s.GetName();
                    spell.lbComp.Content = s.GetComponents();
                    spell.lbSlot.Content = s.GetLevel() + " Slot";
                    panelSpells.Children.Add(spell);  
                }
            }

            spellMod = c.GetModifier(c.GetSpellMod()) + c.GetProfiencyBonus();
            lbSpellMod.Content = "Casting modifier: " + spellMod;
            spellDc = c.GetModifier(c.GetSpellMod()) + c.GetProfiencyBonus() + 8;
            lbSpellSaveDC.Content = "Save DC: " + spellDc;

            //c.SetSlots(3, 3, 3, 3, 3, 3, 3, 3, 3);
        }

        private void UpdateFeatures()
        {
            List<int> acquiredFeatureIds = db.GetCharacterClassFeaturesIds(c.GetID());
            List<Feature> allClassFeatures = db.GetFeaturesByClass(Convert.ToString(c.GetClass()));
            List<Feature> acquiredClassFeatures = new List<Feature>();

            foreach (int i in acquiredFeatureIds)
            {
                foreach (Feature f in allClassFeatures)
                {
                    if (f.id == i)
                    {
                        acquiredClassFeatures.Add(f);
                        break;
                    }
                }
            }
            c.SetClassFeatures(acquiredClassFeatures);

            panelFeatures.Children.Clear();
            features = c.GetAllFeatures();
            FeatureControl temp;

            foreach (Feature f in features)
            {
                temp = new FeatureControl(f.id, true, f);
                temp.lbName.Content = f.GetName();
                panelFeatures.Children.Add(temp);
            }
        }

        private void UpdateFeats()
        {
            List<int> acquiredFeatIds = db.GetCharacterClassFeatIds(c.GetID());
            List<Feat> allFeats = db.GetAllFeats();
            List<Feat> acquiredFeats = new List<Feat>();

            foreach (int i in acquiredFeatIds)
            {
                foreach (Feat f in allFeats)
                {
                    if (f.id == i)
                    {
                        acquiredFeats.Add(f);
                        break;
                    }
                }
            }

            c.SetCharFeats(acquiredFeats);
            feats = c.GetFeats();

            FeatControl temp;
            foreach (Feat f in feats)
            {
                temp = new FeatControl(f, true);
                temp.lbFeatName.Content = f.GetName();
                stackFeats.Children.Add(temp);
            }
        }

        public void UpdateStats()
        {
            // Gets the stats from the character object and calculates the approperate modifiers

            lbSTRMod.Content = c.CalcMod("STR", 0);
            lbSTRStat.Content = c.GetStr();

            lbDEXMod.Content = c.CalcMod("DEX", 0);
            lbDEXStat.Content = c.GetDex();

            lbCONMod.Content = c.CalcMod("CON", 0);
            lbCONStat.Content = c.GetCon();

            lbINTMod.Content = c.CalcMod("INT", 0);
            lbINTStat.Content = c.GetInt();

            lbWISMod.Content = c.CalcMod("WIS", 0);
            lbWISStat.Content = c.GetWis();

            lbCHAMod.Content = c.CalcMod("CHA", 0);
            lbCHAStat.Content = c.GetCha();

            lbPassPerc.Content = (10 + c.GetModifier("Perception"));
            lbMove.Content = db.GetRaceMovementById(Convert.ToInt32(c.GetRace()));
        }

        public void UpdateInspiration()
        {
            if (c.GetInspiration())
            {
                imgInsp.Source = imgTemp.Source;
            }
            else
            {
                imgInsp.Source = imgTempDat.Source;
            }
        }

        public void ChooseSpell(Spell spell)
        {
            chosenSpell = spell;

            // Highlighting
            foreach (SpellControl spellCon in panelSpells.Children)
            {
                if (spellCon.GetSpell() == spell)
                {
                    spellCon.Highlight(true);
                }
                else
                {
                    spellCon.Highlight(false);
                }
            }
        }

        public void UpdateHealth()
        {
            lbHealth.Content = "HP: " + c.GetCurrentHealth();
        }

        private void UpdateDeath()
        {
            lbLifeSave.Content = "Life: " + lifeThrow;
            lbDeathSave.Content = "Death: " + deathThrow;
        }



        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PLAYSCREEN");
            ItemChoice i = new ItemChoice(c.GetID());
            i.Show();
        }
        
        private void btnRollCheck_Click(object sender, RoutedEventArgs e)
        {
            RollSkillScreen r = new RollSkillScreen(c, this);
            r.Show();
        }

        private void btnHeart_Click(object sender, RoutedEventArgs e)
        {
            if (c.GetCurrentHealth() - 1 != -1)
            {
                c.SetCurrentHealth(c.GetCurrentHealth() - 1);
                UpdateHealth();
            }
        }

        private void btnInspiration_Click(object sender, RoutedEventArgs e)
        {
            c.ToggleInspiration();
            UpdateInspiration();
        }

        private void btnInitiative_Click(object sender, RoutedEventArgs e)
        {
            List<int> results = new List<int>();
            results.Add(DiceThrower.ThrowDice(0, 20, c.GetModifier("DEX")));
            log.DisplayResult(results);
        }

        private void btnHitDie_Click(object sender, RoutedEventArgs e)
        {
            int hitDice;
            hitDice = db.GetHitDiceByClass(c.GetClass());
        }

        private void btnHeart_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void menuHeal_Click(object sender, RoutedEventArgs e)
        {
            AddNumber a = new AddNumber(this, "HEAL");
            a.Show();
        }

        private void menuDeath_Click(object sender, RoutedEventArgs e)
        {
            if (DiceThrower.ThrowDice(0, 20, 0) >= 10)
            {
                log.Write("Death saving throw: Life");
                lifeThrow++;

                if (lifeThrow == 3)
                {
                    MessageBox.Show("Stablised!");
                    lifeThrow = 0;
                    deathThrow = 0;
                }
            }
            else
            {   
                log.Write("Death saving throw: Death");
                deathThrow++;

                if (deathThrow == 3)
                {
                    MessageBox.Show("Farewell.");
                    deathThrow = 0;
                    lifeThrow = 0;
                }
            }
            UpdateDeath();
        }

        private void PerformSavingThrow(string stat, bool advantage, bool disadvantage)
        {
            string[] throws = c.GetSavingThrows();
            int mod = 0;
            List<int> result = new List<int>();
            mod += c.GetModifier(stat);

            if (throws[0] == stat || throws[1] == stat)
            {
                mod += c.GetProfiencyBonus();
            }

            if (advantage || disadvantage)
            {
                if (advantage)
                {
                    result.Add(DiceThrower.ThrowSavingThrowAdvantage(mod, true));
                }
                else
                {
                    result.Add(DiceThrower.ThrowSavingThrowAdvantage(mod, false));
                }
            }
            else
            {
                result.Add(DiceThrower.ThrowSavingThrow(mod));
            }

            log.DisplayResult(result);
        }

        private void menuHurt_Click(object sender, RoutedEventArgs e)
        {
            AddNumber a = new AddNumber(this, "DAMAGE");
            a.Show();
        }

        public Character GetCharacter()
        {
            return c;
        }

        private void rectCha_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PerformSavingThrow("CHA", false, false);
        }

        private void rectWis_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PerformSavingThrow("WIS", false, false);
        }

        private void rectInt_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PerformSavingThrow("INT", false, false);
        }

        private void rectCon_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PerformSavingThrow("CON", false, false);
        }

        private void rectDex_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PerformSavingThrow("DEX", false, false);
        }

        private void rectStr_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PerformSavingThrow("STR", false, false);
        }

        private void menuStrAdv_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("STR", true, false);
        }

        private void menuStrDis_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("STR", false, true);
        }

        private void menuDexAdv_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("DEX", true, false);
        }

        private void menuDexDis_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("DEX", false, true);
        }

        private void menuConAdv_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("CON", true, false);
        }

        private void menuConDis_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("CON", false, true);
        }

        private void menuIntAdv_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("INT", true, false);
        }

        private void menuIntDis_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("INT", false, true);
        }

        private void menuWisAdv_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("WIS", true, false);
        }

        private void menuWisDis_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("WIS", false, true);
        }

        private void menuChaAdv_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("CHA", true, false);
        }

        private void menuChaDis_Click(object sender, RoutedEventArgs e)
        {
            PerformSavingThrow("CHA", false, true);
        }

        private void btnPrepareSpells_Click(object sender, RoutedEventArgs e)
        {
            PrepareSpells prep = new PrepareSpells(this, c);
            prep.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CustomAttack cust = new CustomAttack(c, this);
            cust.Show();
        }

        private void btnCast_Click(object sender, RoutedEventArgs e)
        {
            if (chosenSpell == null)
            {
                MessageBox.Show("No spell selected.");
            }
            else
            {
                if (chosenSpell.GetLevel() == 0)
                {
                    log.Write("You cast " + chosenSpell.GetName());
                }
                else
                {
                    if (c.SpendSlot(chosenSpell.GetLevel()))
                    {
                        log.Write("You cast " + chosenSpell.GetName());
                    }
                    else
                    {
                        MessageBox.Show("No level " + chosenSpell.GetLevel() + " slot available");
                    }
                }
            }
        }

        public void CastAtHigherLevel(byte slot)
        {
            if (chosenSpell.GetLevel() > slot)
            {
                MessageBox.Show("Spell slot " + slot + " is too weak to process this spell.");
            }
            else
            {
                if (chosenSpell.GetLevel() == 0)
                {
                    MessageBox.Show("Cantrips can not be cast with higher level slots.");
                }
                else
                {
                    if (c.SpendSlot(slot))
                    {
                        log.Write("You cast " + chosenSpell.GetName());
                    }
                    else
                    {
                        MessageBox.Show("No level " + slot + " slot available");
                    }
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddNumber add = new AddNumber(this, "SPELL");
            add.Show();
        }
    }
}
