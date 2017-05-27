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
using BattleScribe.Forms.Pop_ups.Features;
using BattleScribe.Forms.Pop_ups.Items.Money;

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
        public List<Spell> spells;
        private Character c;
        private CharacterClass cClass;
        private DbHandler db;
        private List<Item> itemsInInv, equipedList;
        private List<Feature> acquiredClassFeatures;
        private List<Feat> acquiredFeats;
        public InventoryManager inventory;
        private MoneyManager money;

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
            cClass = new CharacterClass();
            equipedList = new List<Item>();
            charId = character.GetID();

            
            c = db.GetCharacterById(charId);
            cClass = db.GetClassById(c.GetClass());
            skills = db.GetSkillsByCharId(charId);
            langs = db.GetLangsByCharId(charId);
            spells = db.GetSpellsByCharId(charId);
            c.SetKnownSpells(spells);
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
            rtbArmourProfs.Document.Blocks.Clear();
            rtbWepProfs.Document.Blocks.Clear();
            tbTitle.Text = c.GetTitle();
            tbName.Text = c.GetName();
            tbAge.Text = c.GetAge();
            tbAlignment.Text = c.GetAlignment();
            rtbAppearance.Document.Blocks.Add(new Paragraph(new Run(c.GetAppearance())));
            rtbBackstory.Document.Blocks.Add(new Paragraph(new Run(c.GetBackstory())));
            rtbBonds.Document.Blocks.Add(new Paragraph(new Run(c.GetBonds())));
            rtbIdeals.Document.Blocks.Add(new Paragraph(new Run(c.GetIdeals())));
            rtbPersonality.Document.Blocks.Add(new Paragraph(new Run(c.GetPersonality())));
            rtbWepProfs.Document.Blocks.Add(new Paragraph(new Run(cClass.GetWepProfs())));
            rtbArmourProfs.Document.Blocks.Add(new Paragraph(new Run(cClass.GetArmourProfs())));
            tbTitle.Text = c.GetTitle();
            tbSize.Text = c.GetSize();
            lbCarryCapacity.Content = "Carry capacity: " + totalItemWeight.ToString() + " / " + c.CalcCarryWeight().ToString();

            if (c.GetIsMale())
                chMale.IsChecked = true;
            if (c.GetIsFemale())
                chFemale.IsChecked = true;
            rtbFlaws.Document.Blocks.Add(new Paragraph(new Run(c.GetFlaws())));

            ItemLegend itemLegend = new ItemLegend();
            ItemLegend equipedLegend = new ItemLegend();
            panelInv.Children.Add(itemLegend);
            panelEquiped.Children.Add(equipedLegend);

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

            UpdateSpells();


            inventory = new InventoryManager(c, panelInv, lbCarryCapacity);
            money = new MoneyManager(c, this);

            UpdateStats();
            UpdateFeatureList();
            UpdateFeatList();
        }

        public void UpdateSpells()
        {
            panelSpells.Children.Clear();
            foreach (Spell s in spells)
            {
                SpellPrepControl pSpells = new SpellPrepControl(s);
                panelSpells.Children.Add(pSpells);
            }
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

            AddHealth add = new AddHealth(curHPNum, c.GetModifier("CON"), c.GetClass(), this);
            add.Show();
        }

        public void SetNewHealth(int HP)
        {
            tbCurHP.Text = HP.ToString();
        }

        private void btnAddFeat_Click(object sender, RoutedEventArgs e)
        {
            AddFeat add = new AddFeat(this, c);
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

        public void UpdateFeatList()
        {
            //Connect to the character database later, fill in dynamically
            stackFeats.Children.Clear();

            List<int> featIds = db.GetCharacterClassFeatIds(c.GetID());
            List<Feat> allFeats = db.GetAllFeats();
            acquiredFeats = new List<Feat>();

            foreach (int i in featIds)
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

            foreach (Feat f in feats)
            {
                //Make some childeren :^)
                FeatControl feat = new FeatControl(f, false);
                feat.lbFeatName.Content = f.GetName();
                stackFeats.Children.Add(feat);
            }
        }

        public void UpdateFeatureList()
        {
            List<int> featureClassIds = db.GetCharacterClassFeaturesIds(c.GetID());
            List<Feature> allClassFeatures = db.GetFeaturesByClass(Convert.ToString(c.GetClass()));
            acquiredClassFeatures = new List<Feature>();

            stackFeatures.Children.Clear();

            foreach (int i in featureClassIds)
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

            foreach (Feature f in acquiredClassFeatures)
            {
                FeatureControl feature = new FeatureControl(f.id, false, f);
                feature.lbName.Content = f.GetName();
                stackFeatures.Children.Add(feature);
            }

            // Merge acquired features with race features here, then transform them into stackpanels
            charRaces = db.GetRaces();
            foreach(CharacterRace r in charRaces)
            {
                if (Convert.ToInt32(c.GetRace()) == r.GetId())
                {
                    raceFeatures = db.GetFeaturesByRace(r.GetName());
                }
            }


            foreach (Feature f in raceFeatures)
            {
                FeatureControl feature = new FeatureControl(f.id, true, f);
                feature.lbName.Content = f.GetName();
                stackFeatures.Children.Add(feature);
            }
        }

        private void btnRemoveFeat_Click(object sender, RoutedEventArgs e)
        {
            // List of Feat IDs that need to be removed.

            List<int> ToRemoveIds = new List<int>();

            foreach (FeatControl fcon in stackFeats.Children)
            {
                if (fcon.GetSelect())
                {
                    ToRemoveIds.Add(fcon.feat.id);
                }
            }

            db.RemoveFeats(c.GetID(), ToRemoveIds);
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

        private void btnAddFeature_Click(object sender, RoutedEventArgs e)
        {
            AddFeature add = new AddFeature(c, this);
            add.Show();
        }


        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();
            this.Close();
		}

        private void btnRemoveFeature_Click(object sender, RoutedEventArgs e)
        {
            List<int> ToRemoveIds = new List<int>();

            foreach (FeatureControl fcon in stackFeatures.Children)
            {
                if (fcon.isSelected)
                {
                    ToRemoveIds.Add(fcon.feature.id);
                }
            }

            db.RemoveFeatures(c.GetID(), ToRemoveIds);
            UpdateFeatureList();
        }

        private void btnDropItem_Click(object sender, RoutedEventArgs e)
        {
            List<ItemControl> loopList = new List<ItemControl>();

            foreach (ItemControl i in panelInv.Children.OfType<ItemControl>())
            {
                loopList.Add(i);
            }

            foreach (ItemControl i in loopList)
            {
                if (i.GetIsSelected())
                {
                    switch (i.typeItem)
                    {
                        default:
                            MessageBox.Show("INVALID ITEM TYPE!");
                            break;

                        case "WEAPON":
                            Weapon wep = (Weapon)i.GetItem();
                            inventory.RemoveWeapon(wep);
                            break;

                        case "ARMOUR":
                            Armour a = (Armour)i.GetItem();
                            inventory.RemoveArmour(a);
                            break;

                        case "ITEM":
                            Item it = (Item)i.GetItem();
                            inventory.RemoveItem(it);
                            break;
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            inventory.SaveInventory();

            int[] temp = new int[spells.Count];
            int i = 0;

            foreach (Spell s in spells)
            {
                temp[i] = Convert.ToInt32(s.GetId());
                i++;
            }

            db.InsertSpells(temp, c.GetID());
            
        }

        private void btnRemSpell_Click(object sender, RoutedEventArgs e)
        {
            List<SpellPrepControl> loopList = new List<SpellPrepControl>();

            foreach(SpellPrepControl prep in panelSpells.Children)
            {
                if(prep.isSelected)
                {
                    spells.Remove(prep.GetSpell());
                }
            }
            UpdateSpells();
            
        }

        private void BtnEquip_Click(object sender, RoutedEventArgs e)
        {
            List<ItemControl> loopList = new List<ItemControl>();

            foreach (ItemControl i in panelInv.Children.OfType<ItemControl>())
            {
                loopList.Add(i);
            }

            foreach (ItemControl i in panelEquiped.Children.OfType<ItemControl>())
            {
                loopList.Add(i);
            }

            foreach (ItemControl i in loopList)
            {
                if (i.GetIsSelected())
                {
                    i.SetIsSelected(false);
                    i.ResetColour();
                    switch (i.typeItem)
                    {
                        default:
                            MessageBox.Show("INVALID ITEM TYPE!");
                            break;

                        case "WEAPON":
                            Weapon wep = (Weapon)i.GetItem();
                            if(!wep.GetEquip())
                            {
                                wep.SetEquip(true);
                                equipedList.Add(wep);
                                panelInv.Children.Remove(i);
                                panelEquiped.Children.Add(i);
                            }
                            else
                            {
                                wep.SetEquip(false);
                                equipedList.Remove(wep);
                                panelEquiped.Children.Remove(i);
                                panelInv.Children.Add(i);
                            }
                            break;

                        case "ARMOUR":
                            Armour a = (Armour)i.GetItem();
                            if(!a.GetEquip())
                            {
                               a.SetEquip(true);
                               equipedList.Add(a);
                               panelInv.Children.Remove(i);
                               panelEquiped.Children.Add(i);
                            }
                            else
                            {
                                a.SetEquip(false);
                                equipedList.Remove(a);
                                panelEquiped.Children.Remove(i);
                                panelInv.Children.Add(i);
                            }
                            break;

                        case "ITEM":
                            Item it = (Item)i.GetItem();
                            if (!it.GetEquip())
                            {
                                it.SetEquip(true);
                                equipedList.Add(it);
                                panelInv.Children.Remove(i);
                                panelEquiped.Children.Add(i);
                            }
                            else
                            {
                                it.SetEquip(false);
                                equipedList.Remove(it);
                                panelEquiped.Children.Remove(i);
                                panelInv.Children.Add(i);
                            }
                            break;
                    }
                    
                    inventory.SetEquipedItems(equipedList);
                }
            }
        }

        private void btnAddMoney_Click(object sender, RoutedEventArgs e)
        {
            AddMoney add = new AddMoney(money);
            add.Show();
        }

        private void btnLoseMoney_Click(object sender, RoutedEventArgs e)
        {
            SpendMoney spend = new SpendMoney(money);
            spend.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            money.SaveMoney();
        }
    }
}
