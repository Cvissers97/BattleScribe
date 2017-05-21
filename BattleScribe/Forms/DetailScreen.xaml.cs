using BattleScribe.Classes;
using BattleScribe.Controls.Feats;
using BattleScribe.Controls.Features;
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
using System.Windows.Shapes;
using BattleScribe.Controls.Spells;
using BattleScribe.Forms.Pop_ups.Items;
using BattleScribe.Classes.Items;
using BattleScribe.Controls.Items;

namespace BattleScribe.Forms
{
    /// <summary>
    /// Interaction logic for DetailScreen.xaml
    /// </summary>
    public partial class DetailScreen : Window
    {
        public int charId;
        private int curHPNum, totalItemWeight;
        private List<Feat> feats;
        private List<Feature> raceFeatures;
        private List<CharacterRace> charRaces;
        private List<Skill> skills;
        private List<Language> langs;
        private List<Spell> spells;
        private Character c;
        private DbHandler db;
        private List<Item> itemsInInv;

        public DetailScreen()
        {
            InitializeComponent();

            feats = new List<Feat>();
            raceFeatures = new List<Feature>();
            db = new DbHandler();

            curHPNum = 0;
            UpdateFeatList();

            //Temporary character
            c = new Character();
            c.SetRace("Drow Elf");

            UpdateFeatureList();
        }

        private void UpdateStats()
        {
            lbSTR.Content = "STR " + c.GetStr() + " " + "(" + c.GetModifier("STR") + ")";
            lbDEX.Content = "DEX " + c.GetDex() + " " + "(" + c.GetModifier("DEX") + ")";
            lbCON.Content = "CON " + c.GetCon() + " " + "(" + c.GetModifier("CON") + ")";
            lbINT.Content = "INT " + c.GetInt() + " " + "(" + c.GetModifier("INT") + ")";
            lbWIS.Content = "WIS " + c.GetWis() + " " + "(" + c.GetModifier("WIS") + ")";
            lbCHA.Content = "CHA " + c.GetCha() + " " + "(" + c.GetModifier("CHA") + ")";
        }

        public DetailScreen(BattleScribe.Classes.Character character, Image i)
        {
            InitializeComponent();
            feats = new List<Feat>();
            raceFeatures = new List<Feature>();
            db = new DbHandler();
            charRaces = new List<CharacterRace>();
            skills = new List<Skill>();
            imgChar.Source = i.Source;
            langs = new List<Language>();
            spells = new List<Spell>();
            itemsInInv = new List<Item>();
            charId = character.GetID();

            c = db.GetCharacterById(charId);
            skills = db.GetSkillsByCharId(charId);
            langs = db.GetLangsByCharId(charId);
            spells = db.GetSpellsByCharId(charId);
            c.SetSkillList(skills);
            c.SetLangList(langs);
            Init();

        }

        private void Init()
        {
            rtbAppearance.Document.Blocks.Clear();
            rtbBackstory.Document.Blocks.Clear();
            rtbBonds.Document.Blocks.Clear();
            rtbIdeals.Document.Blocks.Clear();
            rtbPersonality.Document.Blocks.Clear();
            tbTitle.Text = c.GetTitle();
            tbName.Text = c.GetName();
            tbAge.Text = c.GetAge();
            tbAlignment.Text = c.GetAlignment();
            rtbAppearance.Document.Blocks.Add(new Paragraph(new Run(c.GetAppearance())));
            rtbBackstory.Document.Blocks.Add(new Paragraph(new Run(c.GetBackstory())));
            rtbBonds.Document.Blocks.Add(new Paragraph(new Run(c.GetBonds())));
            rtbIdeals.Document.Blocks.Add(new Paragraph(new Run(c.GetIdeals())));
            rtbPersonality.Document.Blocks.Add(new Paragraph(new Run(c.GetPersonality())));
            tbTitle.Text = c.GetTitle();
            tbSize.Text = c.GetSize();
            lbCarryCapacity.Content = "Carry capacity: " + totalItemWeight.ToString() + " / " + c.CalcCarryWeight().ToString();

            if (c.GetIsMale())
                chMale.IsChecked = true;
            if (c.GetIsFemale())
                chFemale.IsChecked = true;
            rtbFlaws.Document.Blocks.Add(new Paragraph(new Run(c.GetFlaws())));

            ItemLegend itemLegend = new ItemLegend();
            panelInv.Children.Add(itemLegend);

            foreach (Skill s in skills)
            {
                CheckBox cBox = new CheckBox();
                cBox.IsChecked = s.acquired;
                cBox.Content = s.name;
                panelSkills.Children.Add(cBox);
            }

            foreach (Language l in langs)
            {
                CheckBox cbox = new CheckBox();
                cbox.IsChecked = l.acquired;
                cbox.Content = l.name;
                panelLanguages.Children.Add(cbox);
            }

            foreach (Spell s in spells)
            {
                SpellPrepControl pSpells = new SpellPrepControl(s);
                panelSpells.Children.Add(pSpells);
            }


            UpdateStats();
            UpdateFeatureList();
            UpdateFeatList();
        }

        private void btnPlusHP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                curHPNum = Convert.ToInt16(tbCurHP.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                throw;
            }

            AddHealth add = new AddHealth(curHPNum, 3, "Wizard", this);
            add.Show();
        }

        public void SetNewHealth(int HP)
        {
            tbCurHP.Text = HP.ToString();
        }

        private void btnAddFeat_Click(object sender, RoutedEventArgs e)
        {
            AddFeat add = new AddFeat(this);
            add.Show();
        }

        public void AddNewFeat(Feat feat)
        {
            feats.Add(feat);
            UpdateFeatList();
        }

        private int CalcWeigth()
        {
            int temp = 0;

            return temp;
        }

        private void UpdateFeatList()
        {
            //Connect to the character database later, fill in dynamically

            stackFeats.Children.Clear();

            foreach (Feat f in feats)
            {
                //Make new entries for the scrollviewer
                FeatControl feat = new FeatControl(f.id);
                feat.lbFeatName.Content = f.GetName();
                stackFeats.Children.Add(feat);
            }
        }

        private void UpdateFeatureList()
        {
            // Merge acquired features with race features here, then transform them into stackpanels
            charRaces = db.GetRaces();
            foreach(CharacterRace r in charRaces)
            {
                if (Convert.ToInt32(c.GetRace()) == r.GetId())
                {
                    raceFeatures = db.GetFeaturesByRace(r.GetName());
                }
            }

            stackFeatures.Children.Clear();

            foreach (Feature f in raceFeatures)
            {
                FeatureControl feature = new FeatureControl(f.id, true);
                feature.lbName.Content = f.GetName();
                stackFeatures.Children.Add(feature);
            }
        }

        private void btnRemoveFeat_Click(object sender, RoutedEventArgs e)
        {
            // List of Feat IDs that need to be removed.
            List<int> remIdList = new List<int>();
            List<Feat> newFeats = new List<Feat>();

            if (feats.Count > 0)
            {
                foreach (Feat f in feats)
                {
                    newFeats.Add(f);
                }
            }


            foreach (FeatControl featCon in stackFeats.Children)
            {
                if (featCon.GetSelect())
                {
                    remIdList.Add(featCon.GetID());
                }
            }

            foreach (int i in remIdList)
            {
                foreach (Feat f in feats)
                {
                    if (f.id == i)
                    {
                        newFeats.Remove(f);
                    }
                }
            }

            feats = newFeats;
            UpdateFeatList();
        }

        private void btnAddSpell_Click(object sender, RoutedEventArgs e)
        {
            AddSpell a = new AddSpell(this);
            a.Show();
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            ItemChoice temp = new ItemChoice(this);
            temp.Show();
		}

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            PlayScreen play = new PlayScreen(c);
            play.Show();
            this.Close();
        }

        private void btnPlusSTR_Click(object sender, RoutedEventArgs e)
        {
            c.SetStr((byte)(c.GetStr() + 1));
            UpdateStats();
        }

        private void btnMinSTR_Click(object sender, RoutedEventArgs e)
        {
            c.SetStr((byte)(c.GetStr() - 1));
            UpdateStats();

        }

        private void btnPlusDEX_Click(object sender, RoutedEventArgs e)
        {
            c.SetDex((byte)(c.GetDex() + 1));
            UpdateStats();

        }

        private void btnMinDEX_Click(object sender, RoutedEventArgs e)
        {
            c.SetDex((byte)(c.GetDex() - 1));
            UpdateStats();

        }

        private void btnPlusCON_Click(object sender, RoutedEventArgs e)
        {
            c.SetCon((byte)(c.GetCon() + 1));
            UpdateStats();

        }

        private void btnMinCON_Click(object sender, RoutedEventArgs e)
        {
            c.SetCon((byte)(c.GetCon() - 1));
            UpdateStats();
        }

        private void btnPlusINT_Click(object sender, RoutedEventArgs e)
        {
            c.SetInt((byte)(c.GetInt() + 1));
            UpdateStats();

        }

        private void btnMinINT_Click(object sender, RoutedEventArgs e)
        {
            c.SetInt((byte)(c.GetInt() - 1));
            UpdateStats();

        }

        private void btnPlusWIS_Click(object sender, RoutedEventArgs e)
        {
            c.SetWis((byte)(c.GetWis() + 1));
            UpdateStats();

        }

        private void btnMinWIS_Click(object sender, RoutedEventArgs e)
        {
            c.SetWis((byte)(c.GetWis() - 1));
            UpdateStats();

        }

        private void btnMinCHA_Click(object sender, RoutedEventArgs e)
        {
            c.SetCha((byte)(c.GetCha() - 1));
            UpdateStats();

        }

        private void btnPlusCHA_Click(object sender, RoutedEventArgs e)
        {
            c.SetCha((byte)(c.GetCha() + 1));
            UpdateStats();
        }

        public void AddItemToInventory(Item i)
        {
            bool duplicate = false;
            foreach (Item item in itemsInInv)
            {
                if (item.GetId() == i.GetId())
                {
                    i.IncrementQuantity();
                    duplicate = true;
                }
            }
            if (!duplicate)
            {
                ItemControl temp = new ItemControl(i);
                panelInv.Children.Add(temp);
                itemsInInv.Add(i);
            }
            UpdateInventory();
            
        }

        private void UpdateInventory()
        {
            panelInv.Children.Clear();

            ItemLegend itemLegend = new ItemLegend();
            panelInv.Children.Add(itemLegend);

            foreach (Item i in itemsInInv)
            {
                if (i.GetType().Name == "Item")
                {
                    ItemControl itemC = new ItemControl(i);
                    panelInv.Children.Add(itemC);
                }
                else if (i.GetType().Name == "Weapon")
                {
                    ItemControl itemC = new ItemControl((Weapon)i);
                    panelInv.Children.Add(itemC);
                }

            }
            UpdateCarryCapacity();
        }

        public List<Item> GetItemsInInventory()
        {
            return itemsInInv;
        }

        public void UpdateCarryCapacity()
        {
            totalItemWeight = 0;
            foreach (Item i in itemsInInv)
            {
                string weight = i.GetWeight();
                string temp = string.Empty;
                int result;
                
                for (int j = 0; j < weight.Length; j++)
                {
                    if (int.TryParse(weight[j].ToString(), out result))
                    {
                        temp += weight[j];
                    }
                    else
                    {
                        break;
                    }
                }

                if (temp != "")
                {
                    result = (Convert.ToInt32(temp) * i.GetQuantity()); 
                    totalItemWeight += result;
                }
            }
            lbCarryCapacity.Content = "Carry capacity: " + totalItemWeight.ToString() + " / " + c.CalcCarryWeight().ToString();
        }
    }
}
