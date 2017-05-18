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

namespace BattleScribe.Forms
{
    /// <summary>
    /// Interaction logic for DetailScreen.xaml
    /// </summary>
    public partial class DetailScreen : Window
    {
        private int curHPNum, charId;
        private List<Feat> feats;
        private List<Feature> raceFeatures;
        private List<CharacterRace> charRaces;
        private List<Skill> skills;
        private List<Language> langs;
        private Character c;
        private DbHandler db;

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
            charId = character.GetID();
            

            c = db.GetCharacterById(charId);
            skills = db.GetSkillsByCharId(charId);
            langs = db.GetLangsByCharId(charId);
            Init();

        }

        private void Init()
        {
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

            if (c.GetIsMale())
                chMale.IsChecked = true;
            if (c.GetIsFemale())
                chFemale.IsChecked = true;
            rtbFlaws.Document.Blocks.Add(new Paragraph(new Run(c.GetFlaws())));

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
            AddSpell a = new AddSpell();
            a.Show();
        }
    }
}
