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

namespace BattleScribe.Forms.Pop_ups.Feats
{
    /// <summary>
    /// Interaction logic for ViewFeat.xaml
    /// </summary>
    public partial class ViewFeat : Window
    {
        private Feat feat;

        public ViewFeat()
        {
            InitializeComponent();
        }

        public ViewFeat(Feat feat)
        {
            InitializeComponent();

            this.feat = feat;

            tbName.Text = feat.GetName();
            tbPrereq.Text = feat.GetPrereq();

            rtbDesc.Document.Blocks.Clear();
            rtbDesc.Document.Blocks.Add(new Paragraph(new Run(feat.GetDesc())));
        }
    }
}
