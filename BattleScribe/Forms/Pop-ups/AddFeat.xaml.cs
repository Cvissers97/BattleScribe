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
    /// <summary>
    /// Interaction logic for AddFeat.xaml
    /// </summary>
    public partial class AddFeat : Window
    {
        private List<Feat> feats;
        private DetailScreen detail;

        public AddFeat()
        {
            InitializeComponent();
        }

        public AddFeat(DetailScreen detail)
        {
            InitializeComponent();

            this.detail = detail;
            feats = new List<Feat>();

            // Temporary feats for testing purposes
            Feat temp;
            temp = new Feat("Grappler", "Grapples people", "13 Strength", 1);
            feats.Add(temp);
            temp = new Feat("Magic Initiate", "Spells, pew pew.", "13 Intelligence", 2);
            feats.Add(temp);

            foreach (Feat f in feats)
            {
                cbFeat.Items.Add(f);
            }
        }

        private void cbFeat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Feat temp = (Feat)cbFeat.SelectedItem;
                tbPrereq.Text = temp.GetPrereq();
                rtbDesc.Document.Blocks.Clear();
                rtbDesc.Document.Blocks.Add(new Paragraph(new Run(temp.GetDesc())));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);    
                throw;
            } 
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbFeat.SelectedItem != null)
            {
                Feat temp = (Feat)cbFeat.SelectedItem;
                detail.AddNewFeat(temp);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a Feat!");
            }
        }
    }
}
