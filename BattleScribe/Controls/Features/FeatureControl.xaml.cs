using BattleScribe.Classes;
using BattleScribe.Forms.Pop_ups.Features;
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

namespace BattleScribe.Controls.Features
{
    /// <summary>
    /// Interaction logic for FeatureControl.xaml
    /// </summary>
    public partial class FeatureControl : UserControl
    {
        private int id;
        private bool isRacial;
        public Feature feature;
        public bool isSelected;
        private Brush normalBackground;

        public FeatureControl()
        {
            InitializeComponent();
        }

        public FeatureControl(int id, bool racial, Feature feature)
        {
            InitializeComponent();

            this.feature = feature;
            this.id = id;
            this.isRacial = racial;
            normalBackground = this.Background;
            isSelected = false;
        }

        public FeatureControl(int id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!isRacial)
            {
                isSelected = !isSelected;
            }

            if (isSelected)
            {
                this.Background = new SolidColorBrush(System.Windows.Media.Colors.Indigo);
            }
            else
            {
                this.Background = normalBackground;
            }
        }

        private void UserControl_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewFeature view = new ViewFeature(feature.GetName(), feature.GetDesc());
            view.Show();
        }
    }
}
