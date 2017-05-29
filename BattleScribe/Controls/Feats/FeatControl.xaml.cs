using BattleScribe.Classes;
using BattleScribe.Forms.Pop_ups.Feats;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleScribe.Controls.Feats
{
    /// <summary>
    /// Interaction logic for FeatControl.xaml
    /// </summary>
    public partial class FeatControl : UserControl
    {
        private bool isSelected;
        private string name;
        public Feat feat;
        private int id;
        private Brush normalBackground;
        private bool fromPlayScreen;

        public FeatControl()
        {
            InitializeComponent();
        }

        public FeatControl(Feat feat, bool fromPlayScreen)
        {
            InitializeComponent();
            this.feat = feat;
            this.fromPlayScreen = fromPlayScreen;
            this.normalBackground = this.Background;
            isSelected = false;
        }

        private void lbFeatName_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!fromPlayScreen)
            {
                isSelected = !isSelected;
            }

            if (isSelected)
            {
                this.Background = new SolidColorBrush(System.Windows.Media.Colors.Aquamarine);
            }
            else
            {
                this.Background = normalBackground;
            }
        }

        public bool GetSelect()
        {
            return isSelected;
        }

        public int GetID()
        {
            return id;
        }

        private void UserControl_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewFeat view = new ViewFeat(feat);
            view.Show();
        }
    }
}