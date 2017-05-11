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
        private int id;

        public FeatControl()
        {
            InitializeComponent();
        }

        public FeatControl(int id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void lbFeatName_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(System.Windows.Media.Colors.Aquamarine);
            isSelected = true;
        }

        public bool GetSelect()
        {
            return isSelected;
        }

        public int GetID()
        {
            return id;
        }
    }
}