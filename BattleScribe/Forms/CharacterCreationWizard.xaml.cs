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
using BattleScribe.Classes;
using BattleScribe.Forms;
using Microsoft.Win32;
using System.IO;
using BattleScribe.Classes.Items;

namespace BattleScribe.Forms
{
    /// <summary>
    /// Interaction logic for CharacterCreationWizard.xaml
    /// </summary>
    public partial class CharacterCreationWizard : Window
    {
        // Screen count total of 3, starting at 1
        // 1 = Personal, 2 = Statistics, 3 = Magic
        byte screen;
        DbHandler db;
        Character character;
        int totalPoints, cantripsKnown, spellsKnown, charId;
        List<CharacterRace> race;
        byte raceStr, raceDex, raceCon, raceInt, raceWis, raceCha;
        List<string> allLangs, allSkills;
        List<Spell> spellList, cantripList, pickedSpells;
        List<CheckBox> cbSpellList, cbLangList, cbSkillList, cbCantripList;
        string[] spellsKnownArray;
        Image image;
        byte[] imageArray;

        public CharacterCreationWizard()
        {
            db = new DbHandler();
            character = new Character();
            InitializeComponent();
            Init();
            screen = 1;
            UpdateScreen();
            totalPoints = 27; // max amount of points according to D&D rules
            lbPoints.Content = "Total Points: " + totalPoints;
            cbSpellList = new List<CheckBox>();
            cbBackgrounds.Items.Add("Hermit");
        }
        
        //Add all stats to a list
        public List<byte> StatList()
        {
            List<byte> temp = new List<byte>();
            temp.Add(character.GetStr());
            temp.Add(character.GetDex());
            temp.Add(character.GetCon());
            temp.Add(character.GetInt());
            temp.Add(character.GetWis());
            temp.Add(character.GetCha());

            return temp;
        }

        //Calc the points you have left with the pointbuy system
        public int CalcPoints()
        {
            totalPoints = 27;
            List<byte> AllStat = StatList();

            foreach (byte b in AllStat)
            {
                switch (b)
                {
                    case 9:
                        totalPoints -= 1;
                        break;
                    case 10:
                        totalPoints -= 2;
                        break;
                    case 11:
                        totalPoints -= 3;
                        break;
                    case 12:
                        totalPoints -= 4;
                        break;
                    case 13:
                        totalPoints -= 5;
                        break;
                    case 14:
                        totalPoints -= 7;
                        break;
                    case 15:
                        totalPoints -= 9;
                        break;
                    default:
                        break;
                }
            }
           return totalPoints;
        }

        //Handels screen transistions
        private void UpdateScreen()
        {
            btnFinish.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;

            if ((screen - 1) == 0)
            {
                btnBack.IsEnabled = false;
            }
            else
            {
                btnBack.IsEnabled = true;
            }

            if ((screen + 1) == 4)
            {
                btnNext.IsEnabled = false;
                btnNext.Visibility = Visibility.Hidden;
                btnFinish.Visibility = Visibility.Visible;
            }
            else
            {
                btnNext.IsEnabled = true;
            }

            //Make everything invisible. The choose what to show.
            // PERSONAL
            lbName.Visibility = Visibility.Hidden;
            lbAge.Visibility = Visibility.Hidden;
            lbSize.Visibility = Visibility.Hidden;
            lbGender.Visibility = Visibility.Hidden;
            chMale.Visibility = Visibility.Hidden;
            chFemale.Visibility = Visibility.Hidden;
            imgChar.Visibility = Visibility.Hidden;
            btnUpload.Visibility = Visibility.Hidden;
            lbAppearance.Visibility = Visibility.Hidden;
            rtbAppearance.Visibility = Visibility.Hidden;
            tbName.Visibility = Visibility.Hidden;
            tbAge.Visibility = Visibility.Hidden;
            tbSize.Visibility = Visibility.Hidden;
            lbAgeExtra.Visibility = Visibility.Hidden;
            lbSizeExtra.Visibility = Visibility.Hidden;
            lbTitle.Visibility = Visibility.Hidden;
            lbAlignment.Visibility = Visibility.Hidden;
            tbTitle.Visibility = Visibility.Hidden;
            tbAlignment.Visibility = Visibility.Hidden;
            lbPersonality.Visibility = Visibility.Hidden;
            rtbPersonality.Visibility = Visibility.Hidden;
            lbFlaws.Visibility = Visibility.Hidden;
            rtbFlaws.Visibility = Visibility.Hidden;
            lbIdeals.Visibility = Visibility.Hidden;
            rtbIdeals.Visibility = Visibility.Hidden;
            lbBonds.Visibility = Visibility.Hidden;
            rtbBonds.Visibility = Visibility.Hidden;
            lbBackstory.Visibility = Visibility.Hidden;
            rtbBackstory.Visibility = Visibility.Hidden;

            // STATISTICS
            lbRace.Visibility = Visibility.Hidden;
            lbClass.Visibility = Visibility.Hidden;
            cbRaces.Visibility = Visibility.Hidden;
            cbClasses.Visibility = Visibility.Hidden;
            lbSTR.Visibility = Visibility.Hidden;
            lbDEX.Visibility = Visibility.Hidden;
            lbCON.Visibility = Visibility.Hidden;
            lbINT.Visibility = Visibility.Hidden;
            lbWIS.Visibility = Visibility.Hidden;
            lbCHA.Visibility = Visibility.Hidden;
            btnPlusSTR.Visibility = Visibility.Hidden;
            btnMinSTR.Visibility = Visibility.Hidden;
            btnPlusDEX.Visibility = Visibility.Hidden;
            btnMinDEX.Visibility = Visibility.Hidden;
            btnPlusCON.Visibility = Visibility.Hidden;
            btnMinCON.Visibility = Visibility.Hidden;
            btnPlusINT.Visibility = Visibility.Hidden;
            btnMinINT.Visibility = Visibility.Hidden;
            btnPlusWIS.Visibility = Visibility.Hidden;
            btnMinWIS.Visibility = Visibility.Hidden;
            btnPlusCHA.Visibility = Visibility.Hidden;
            btnMinCHA.Visibility = Visibility.Hidden;
            lbPoints.Visibility = Visibility.Hidden;
            lbBackground.Visibility = Visibility.Hidden;
            cbBackgrounds.Visibility = Visibility.Hidden;
            panelSkills.Visibility = Visibility.Hidden;
            lbSkills.Visibility = Visibility.Hidden;
            lbMiscProf.Visibility = Visibility.Hidden;
            rtbMiscProf.Visibility = Visibility.Hidden;
            panelLanguages.Visibility = Visibility.Hidden;
            lbLanguage.Visibility = Visibility.Hidden;

            // MAGIC
            lbCantrip.Visibility = Visibility.Hidden;
            panelCantrips.Visibility = Visibility.Hidden;
            lbKnownSpells.Visibility = Visibility.Hidden;
            panelKnownSpells.Visibility = Visibility.Hidden;
            panelPrepSpells.Visibility = Visibility.Hidden;
            lbPrepSpells.Visibility = Visibility.Hidden;
            btnPrepare.Visibility = Visibility.Hidden;
            btnUnprepare.Visibility = Visibility.Hidden;

            switch (screen)
            {
                case 1:
            // Show all contents of the 'personal' screen.
            lbName.Visibility = Visibility.Visible;
            lbAge.Visibility = Visibility.Visible;
            lbSize.Visibility = Visibility.Visible;
            lbGender.Visibility = Visibility.Visible;
            chMale.Visibility = Visibility.Visible;
            chFemale.Visibility = Visibility.Visible;
            imgChar.Visibility = Visibility.Visible;
            btnUpload.Visibility = Visibility.Visible;
            lbAppearance.Visibility = Visibility.Visible;
            rtbAppearance.Visibility = Visibility.Visible;
            tbName.Visibility = Visibility.Visible;
            tbAge.Visibility = Visibility.Visible;
            tbSize.Visibility = Visibility.Visible;
            lbAgeExtra.Visibility = Visibility.Visible;
            lbSizeExtra.Visibility = Visibility.Visible;
            lbTitle.Visibility = Visibility.Visible;
            lbAlignment.Visibility = Visibility.Visible;
            tbTitle.Visibility = Visibility.Visible;
            tbAlignment.Visibility = Visibility.Visible;
            lbPersonality.Visibility = Visibility.Visible;
            rtbPersonality.Visibility = Visibility.Visible;
            lbFlaws.Visibility = Visibility.Visible;
            rtbFlaws.Visibility = Visibility.Visible;
            lbIdeals.Visibility = Visibility.Visible;
            rtbIdeals.Visibility = Visibility.Visible;
            lbBonds.Visibility = Visibility.Visible;
            rtbBonds.Visibility = Visibility.Visible;
            lbBackstory.Visibility = Visibility.Visible;
            rtbBackstory.Visibility = Visibility.Visible;
                    break;

                case 2:
            // Show all contents of the 'statistics' screen.
            lbRace.Visibility = Visibility.Visible;
            lbClass.Visibility = Visibility.Visible;
            cbRaces.Visibility = Visibility.Visible;
            cbClasses.Visibility = Visibility.Visible;
            lbSTR.Visibility = Visibility.Visible;
            lbDEX.Visibility = Visibility.Visible;
            lbCON.Visibility = Visibility.Visible;
            lbINT.Visibility = Visibility.Visible;
            lbWIS.Visibility = Visibility.Visible;
            lbCHA.Visibility = Visibility.Visible;
            btnPlusSTR.Visibility = Visibility.Visible;
            btnMinSTR.Visibility = Visibility.Visible;
            btnPlusDEX.Visibility = Visibility.Visible;
            btnMinDEX.Visibility = Visibility.Visible;
            btnPlusCON.Visibility = Visibility.Visible;
            btnMinCON.Visibility = Visibility.Visible;
            btnPlusINT.Visibility = Visibility.Visible;
            btnMinINT.Visibility = Visibility.Visible;
            btnPlusWIS.Visibility = Visibility.Visible;
            btnMinWIS.Visibility = Visibility.Visible;
            btnPlusCHA.Visibility = Visibility.Visible;
            btnMinCHA.Visibility = Visibility.Visible;
            lbPoints.Visibility = Visibility.Visible;
            lbBackground.Visibility = Visibility.Visible;
            cbBackgrounds.Visibility = Visibility.Visible;
            panelSkills.Visibility = Visibility.Visible;
            lbSkills.Visibility = Visibility.Visible;
            lbMiscProf.Visibility = Visibility.Visible;
            rtbMiscProf.Visibility = Visibility.Visible;
            panelLanguages.Visibility = Visibility.Visible;
            lbLanguage.Visibility = Visibility.Visible;
                    break;
                    
                case 3:
            // Show all contents of the 'magic' screen.
            lbCantrip.Visibility = Visibility.Visible;
            panelCantrips.Visibility = Visibility.Visible;
            lbKnownSpells.Visibility = Visibility.Visible;
            panelKnownSpells.Visibility = Visibility.Visible;
            panelPrepSpells.Visibility = Visibility.Visible;
            lbPrepSpells.Visibility = Visibility.Visible;
            btnPrepare.Visibility = Visibility.Visible;
            btnUnprepare.Visibility = Visibility.Visible;
                    break;
            }
        }

        //Init general stuff
        private void Init()
        {
            race = db.GetRaces();
            List<CharacterClass> charClass = db.GetClasses();
            allLangs = character.LangList();
            allSkills = character.SkillsList();
            cbSkillList = new List<CheckBox>();
            cbLangList = new List<CheckBox>();

            //fill dropdown with races
            foreach (CharacterRace r in race)
            {
                cbRaces.Items.Add(r.GetName());
            }

            //fill dropdown with classes
            foreach (CharacterClass c in charClass)
            {
                cbClasses.Items.Add(c.GetName());
            }

            //adding all langs to the lang panel. TODO grey out logic depending on race you pick
            foreach (string s in allLangs)
            {
                CheckBox c = new CheckBox();
                c.Content = s;
                c.Padding = new Thickness(5, 0, 5, 0);
                //c.IsEnabled = false;
                panelLanguages.Children.Add(c);
                cbLangList.Add(c);
            }

            //add all skills to the skill panel TODO: amount logic per class and grey out per class
            foreach (string s in allSkills)
            {
                CheckBox c = new CheckBox();
                c.Content = s;
                c.Padding = new Thickness(5, 0, 5, 0);
                //c.IsEnabled = false;
                panelSkills.Children.Add(c);
                cbSkillList.Add(c);
            }
            InitScores();
        }

        //Inits the abillity scores of the character
        private void InitScores()
        {
            lbSTR.Content = "STR" + " " + (character.GetStr() + raceStr) + " (" + character.CalcMod("STR", (double)raceStr) + ")";
            lbDEX.Content = "DEX" + " " + (character.GetDex() + raceDex) + " (" + character.CalcMod("DEX", (double)raceDex) + ")";
            lbCON.Content = "CON" + " " + (character.GetCon() + raceCon) + " (" + character.CalcMod("CON", (double)raceCon) + ")";
            lbINT.Content = "INT" + " " + (character.GetInt() + raceInt) + " (" + character.CalcMod("INT", (double)raceInt) + ")";
            lbWIS.Content = "WIS" + " " + (character.GetWis() + raceWis) + " (" + character.CalcMod("WIS", (double)raceWis) + ")";
            lbCHA.Content = "CHA" + " " + (character.GetCha() + raceCha) + " (" + character.CalcMod("CHA", (double)raceCha) + ")";
        }

        //Handels all the button clicks in this screen
        #region Btn click events
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (screen < 3)
            {
                screen++;
                if (screen == 3)
                {
                    if (cbClasses.SelectedItem != null)
                    {
                        panelKnownSpells.Children.Clear();
                        panelCantrips.Children.Clear();
                        panelPrepSpells.Children.Clear();

                        spellList = db.GetSpellsByClass(cbClasses.SelectedItem.ToString(), 1);

                        cantripList = db.GetSpellsByClass(cbClasses.SelectedItem.ToString(), 0);
                        cbSpellList = new List<CheckBox>();
                        cbCantripList = new List<CheckBox>();

                        if ((string)cbClasses.SelectedItem == "Cleric" || (string)cbClasses.SelectedItem == "Druid")
                        {
                            foreach (Spell s in spellList)
                            {
                                CheckBox c = new CheckBox();
                                c.IsChecked = true;
                                c.Content = s.GetName();
                                c.Margin = new Thickness(5, 0, 5, 0);
                                panelPrepSpells.Children.Add(c);
                                cbSpellList.Add(c);
                                c.PreviewMouseRightButtonUp += (_sender, _e) => SpellRightClick(_sender, _e, s);
                            }
                            btnPrepare.IsEnabled = false;
                            btnUnprepare.IsEnabled = false;
                            lbPrepSpells.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            foreach (Spell s in spellList)
                            {
                                CheckBox c = new CheckBox();
                                c.Content = s.GetName();
                                c.Margin = new Thickness(5, 0, 5, 0);
                                panelKnownSpells.Children.Add(c);
                                cbSpellList.Add(c);
                                c.PreviewMouseRightButtonUp += (_sender, _e) => SpellRightClick(_sender, _e, s);
                            }
                            btnPrepare.IsEnabled = true;
                            btnUnprepare.IsEnabled = true;
                            lbPrepSpells.Visibility = Visibility.Visible;
                        }

                        foreach (Spell s in cantripList)
                        {
                            CheckBox c = new CheckBox();
                            c.Content = s.GetName();
                            c.Margin = new Thickness(5, 0, 5, 0);
                            panelCantrips.Children.Add(c);
                            cbCantripList.Add(c);
                            c.PreviewMouseRightButtonUp += (_sender, _e) => SpellRightClick(_sender, _e, s);
                        }
                    }
                }
                UpdateScreen();
            }
        }

        private void SpellRightClick(object sender, RoutedEventArgs e, Spell s)
        {
            Pop_ups.Spells.ViewSpell view = new Pop_ups.Spells.ViewSpell(s.GetName(), s.GetLevel().ToString(), s.GetRange(), s.GetComponents(), s.GetDuration(), s.GetCastTime(),
                s.GetHigher(), s.GetDesc());
            view.Show();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (screen > 0)
            {
                screen--;
                UpdateScreen();
            }
        }

        private void BtnPlusSTR_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetStr() + 1) < 16)
            {
                character.SetStr((byte)(character.GetStr() + 1));
                if (CalcPoints() >= 0)
                {
                    lbSTR.Content = "STR" + " " + (character.GetStr() + raceStr) + " (" + character.CalcMod("STR", (double)raceStr) + ")";
                    lbPoints.Content = "Total points: " + CalcPoints();
                }
                else 
                character.SetStr((byte)(character.GetStr() - 1));
            }
        }

        private void BtnMinSTR_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetStr() - 1) != 7)
            {
                character.SetStr((byte)(character.GetStr() - 1));
                lbSTR.Content = "STR" + " " + (character.GetStr() + raceStr) + " (" + character.CalcMod("STR", (double)raceStr) + ")";
                lbPoints.Content = "Total points: " + CalcPoints();
            }
        }

        private void BtnMinDEX_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetDex() - 1) != 7)
            {
                character.SetDex((byte)(character.GetDex() - 1));
                lbDEX.Content = "DEX" + " " + (character.GetDex() + raceDex) + " (" + character.CalcMod("DEX", (double)raceDex) + ")";
                lbPoints.Content = "Total points: " + CalcPoints();
            }
        }

        private void BtnPlusDEX_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetDex() + 1) < 16)
            {
                character.SetDex((byte)(character.GetDex() + 1));
                if (CalcPoints() >= 0)
                {
                    lbDEX.Content = "DEX" + " " + (character.GetDex() + raceDex) + " (" + character.CalcMod("DEX", (double)raceDex) + ")";
                    lbPoints.Content = "Total points: " + CalcPoints();
                }
                else
                    character.SetDex((byte)(character.GetDex() - 1));
            }
        }

        private void BtnMinCON_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetCon() - 1) != 7)
            {
                character.SetCon((byte)(character.GetCon() - 1));
                lbCON.Content = "CON" + " " + (character.GetCon() + raceCon) + " (" + character.CalcMod("CON", (double)raceCon) + ")";
                lbPoints.Content = "Total points: " + CalcPoints();
            }
        }

        private void BtnPlusCON_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetCon() + 1) < 16)
            {
                character.SetCon((byte)(character.GetCon() + 1));
                if (CalcPoints() >= 0)
                {
                    lbCON.Content = "CON" + " " + (character.GetCon() + raceCon) + " (" + character.CalcMod("CON", raceCon) + ")";
                    lbPoints.Content = "Total points: " + CalcPoints();
                }
                else
                    character.SetCon((byte)(character.GetCon() - 1));
            }
        }

        private void BtnPlusINT_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetInt() + 1) < 16)
            {
                character.SetInt((byte)(character.GetInt() + 1));
                if (CalcPoints() >= 0)
                {
                    lbINT.Content = "INT" + " " + (character.GetInt() + raceInt) + " (" + character.CalcMod("INT", (double)raceInt) + ")";
                    lbPoints.Content = "Total points: " + CalcPoints();
                }
                else
                    character.SetInt((byte)(character.GetInt() - 1));
            }
        }

        private void BtnMinINT_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetInt() - 1) != 7)
            {
                character.SetInt((byte)(character.GetInt() - 1));
                lbINT.Content = "INT" + " " + (character.GetInt() + raceInt) + " (" + character.CalcMod("INT", (double)raceInt) + ")";
                lbPoints.Content = "Total points: " + CalcPoints();
            }
        }

        private void BtnMinWIS_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetWis() - 1) != 7)
            {
                character.SetWis((byte)(character.GetWis() - 1));
                lbWIS.Content = "WIS" + " " + (character.GetWis() + raceWis) + " (" + character.CalcMod("WIS", (double)raceWis) + ")";
                lbPoints.Content = "Total points: " + CalcPoints();
            }
        }

        private void BtnPlusWIS_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetWis() + 1) < 16)
            {
                character.SetWis((byte)(character.GetWis() + 1));
                if (CalcPoints() >= 0)
                {
                    lbWIS.Content = "WIS" + " " + (character.GetWis() + raceWis) + " (" + character.CalcMod("WIS", (double)raceWis) + ")";
                    lbPoints.Content = "Total points: " + CalcPoints();
                }
                else
                   character.SetWis((byte)(character.GetWis() - 1));
            }
        }

        private void BtnMinCHA_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetCha() - 1) != 7)
            {
                character.SetCha((byte)(character.GetCha() - 1));
                lbCHA.Content = "CHA" + " " + (character.GetCha() + raceCha) + " (" + character.CalcMod("CHA", (double)raceCha) + ")";
                lbPoints.Content = "Total points: " + CalcPoints();
            }
        }

        private void BtnPlusCHA_Click(object sender, RoutedEventArgs e)
        {
            if ((character.GetCha() + 1) < 16)
            {
                character.SetCha((byte)(character.GetCha() + 1));
                if (CalcPoints() >= 0)
                {
                    lbCHA.Content = "CHA" + " " + (character.GetCha() + raceCha) + " (" + character.CalcMod("CHA", (double)raceCha) + ")";
                    lbPoints.Content = "Total points: " + CalcPoints();
                }
                else
                    character.SetCha((byte)(character.GetCha() - 1));
            }
        }

        private void BtnPrepareSpellClick(object sender, RoutedEventArgs e)
        {
            List<CheckBox> temp = new List<CheckBox>();
            foreach (CheckBox c in panelKnownSpells.Children)
            {
                if (c.IsChecked == true)
                {
                    temp.Add(c);
                }
            }

            foreach (CheckBox c in temp)
            {
                spellsKnown -= 1;
                panelKnownSpells.Children.Remove(c);
                panelPrepSpells.Children.Add(c);
                c.IsChecked = false;
            }
            lbPrepSpells.Content = "You can still pick " + spellsKnown + " spells";
        }

        private void BtnUnprepareSpellClick(object sender, RoutedEventArgs e)
        {
            List<CheckBox> temp = new List<CheckBox>();
            foreach (CheckBox c in panelPrepSpells.Children)
            {
                if (c.IsChecked == true)
                {
                    temp.Add(c);
                }
            }

            foreach (CheckBox c in temp)
            {
                spellsKnown += 1;
                panelPrepSpells.Children.Remove(c);
                panelKnownSpells.Children.Add(c);
                c.IsChecked = false;
            }
            lbPrepSpells.Content = "You can still pick " + spellsKnown + " spells";
        }



        private void FinishClick(object sender, RoutedEventArgs e)
        {
            int[] spellIds = new int[panelPrepSpells.Children.Count];
            int temp = 0;

            foreach (CheckBox c in panelCantrips.Children)
            {
                foreach (Spell s in spellList)
                {
                    if ((string)c.Content == s.GetName())
                    {
                        spellIds[temp] = Convert.ToInt32(s.GetId());
                        temp++;
                        break;
                    }
                }
            }

            foreach (CheckBox c in panelPrepSpells.Children)
            {
                foreach (Spell s in spellList)
                {
                    if ((string)c.Content == s.GetName())
                    {
                        spellIds[temp] = Convert.ToInt32(s.GetId());
                        temp++;
                        break;
                    }
                }
            }

            List<bool> chosenSkills = new List<bool>();
            List<bool> chosenLangs = new List<bool>();

            foreach (CheckBox c in panelSkills.Children)
            {
                if (c.IsChecked == true)
                {
                    chosenSkills.Add(true);
                }
                else
                {
                    chosenSkills.Add(false);
                }
            }

            foreach (CheckBox c in panelLanguages.Children)
            {
                if (c.IsChecked == true)
                {
                    chosenSkills.Add(true);
                }
                else
                {
                    chosenSkills.Add(false);
                }
            }


            CreateCharacter();
            //db.InsertSkills;
            //db.InsertLangs;
            db.InsertSpells(spellIds, charId);
        }
        #endregion

        private void CreateCharacter()
        {
            byte tempStr = Convert.ToByte(character.GetStr() + raceStr);
            byte tempDex = Convert.ToByte(character.GetDex() + raceDex);
            byte tempCon = Convert.ToByte(character.GetCon() + raceCon);
            byte tempWis = Convert.ToByte(character.GetWis() + raceWis);
            byte tempInt = Convert.ToByte(character.GetInt() + raceInt);
            byte tempCha = Convert.ToByte(character.GetCha() + raceCha);



            Character charac = new Character(tbName.Text, tbTitle.Text, tbAge.Text, tbSize.Text, tbAlignment.Text, (bool)chFemale.IsChecked, (bool)chMale.IsChecked, 
                GetRichTbString(rtbBonds), GetRichTbString(rtbIdeals), GetRichTbString(rtbAppearance), GetRichTbString(rtbFlaws), GetRichTbString(rtbBackstory), tempStr,
                tempDex, tempCon, tempInt, tempWis, tempCha, (cbClasses.SelectedIndex + 1), GetRichTbString(rtbPersonality), (cbBackgrounds.SelectedIndex + 1).ToString(),
                (cbRaces.SelectedIndex + 1).ToString());

            charId = db.CreateCharacter(charac);
        }

        string GetRichTbString(RichTextBox rtb)
        {
            string text = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
            return text;
        }

        private string[] CalcKnownSpells()
        {
            string[] temp = new string[2];
            cantripsKnown = 0;
            spellsKnown = 0;
            switch (cbClasses.SelectedItem.ToString())
            {
                case "Cleric":
                    cantripsKnown += 3;
                    spellsKnown += -1;
                    break;
                case "Bard":
                    cantripsKnown += 2;
                    spellsKnown += 4;
                    break;
                case "Sorcerer":
                    cantripsKnown += 4;
                    spellsKnown += 2;
                    break;
                case "Wizard":
                    cantripsKnown += 3;
                    spellsKnown += -1;
                    break;
                case "Druid":
                    cantripsKnown += 2;
                    spellsKnown += 2;
                    break;
                case "Warlock":
                    cantripsKnown += 2;
                    spellsKnown += 2;
                    break;
                default:
                    break;
            }
            temp[0] = cantripsKnown.ToString();
            temp[1] = spellsKnown.ToString();

            return temp;
        }

        private void CbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spellsKnownArray = CalcKnownSpells();
            lbPrepSpells.Content = "You can still pick " + spellsKnownArray[0] + " spells.";
        }

        //Racecb selection change to calc race bonus, features and langs
        private void CbRaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //panelLanguages.Children.Clear();
            raceStr = 0;
            raceDex = 0;
            raceCon = 0;
            raceInt = 0;
            raceWis = 0;
            raceCha = 0;

            switch (cbRaces.SelectedItem.ToString())
            {
                case "Human":
                    raceStr = 1;
                    raceDex = 1;
                    raceCon = 1;
                    raceInt = 1;
                    raceWis = 1;
                    raceCha = 1;
                    break;
                case "Hill Dwarf":
                    raceCon = 2;
                    raceWis = 1;
                    break;
                case "Mountain Dwarf":
                    raceCon = 2;
                    raceStr = 2;
                    break;
                case "High Elf":
                    raceInt = 1;
                    raceDex = 2;
                    break;
                case "Wood Elf":
                    raceWis = 1;
                    raceDex = 2;
                    break;
                case "Drow Elf":
                    raceCha = 1;
                    raceDex = 2;
                    break;
                case "Halfling Lightfoot":
                    raceCha = 1;
                    raceDex = 2;
                    break;
                case "Halfling Stout":
                    raceCon = 1;
                    raceDex = 2;
                    break;
                case "Dragonborn":
                    raceStr = 2;
                    raceCon = 1;
                    break;
                case "Forest Gnome":
                    raceDex = 1;
                    raceInt = 2;
                    break;
                case "Deep Gnome":
                    raceInt = 2;
                    raceCon = 1;
                    break;
                case "Half Elf":
                    raceCha = 2;
                    //1 increase in two of choose
                    break;
                case "Half Orc":
                    raceStr = 2;
                    raceCon = 1;
                    break;
                case "Thiefling":
                    raceInt = 1;
                    raceCha = 2;
                    break;
            }
            InitScores();
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            string path = string.Empty;
            OpenFileDialog dlg = new OpenFileDialog();
            BitmapImage temp = null;

            dlg.Title = "Select a picture for your character";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";

            if (dlg.ShowDialog() == true)
            {
                temp = new BitmapImage(new Uri(dlg.FileName));
                imgChar.Source = temp;
            }

            imageArray = System.IO.File.ReadAllBytes(dlg.FileName);
        }
    }
}
