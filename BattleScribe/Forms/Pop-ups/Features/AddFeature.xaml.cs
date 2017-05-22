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

namespace BattleScribe.Forms.Pop_ups.Features
{
    /// <summary>
    /// Interaction logic for AddFeature.xaml
    /// </summary>
    public partial class AddFeature : Window
    {
        private int charId;
        private int charClass;
        private DetailScreen detail;
        private DbHandler db;
        private List<Feature> availableFeatures;
        Feature chosen;

        public AddFeature()
        {
            InitializeComponent();
        }

        public AddFeature(Character chara, DetailScreen detail)
        {
            InitializeComponent();

            this.charId = chara.GetID();
            this.charClass = chara.GetClass();
            this.detail = detail;

            db = new DbHandler();
            availableFeatures = new List<Feature>();

            GetFeatures();
        }

        private void GetFeatures()
        {
            availableFeatures = db.GetFeaturesByClass(Convert.ToString(charClass));

            foreach (Feature f in availableFeatures)
            {
                cbName.Items.Add(f);
            }
        }

        private void cbName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbName.SelectedItem != null)
            {
                chosen = (Feature)cbName.SelectedItem;
                rtbDesc.Document.Blocks.Clear();
                rtbDesc.Document.Blocks.Add(new Paragraph(new Run(chosen.GetDesc())));
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbName.SelectedItem != null)
            {
                if (!db.AddFeatureToCharacter(charId, chosen.id))
                {
                    MessageBox.Show("You already have this feature.");
                }
                else
                {
                    detail.UpdateFeatureList();
                }
            }
        }
    }
}
