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

        public FeatureControl()
        {
            InitializeComponent();
        }

        public FeatureControl(int id, bool racial)
        {
            InitializeComponent();

            this.id = id;
            this.isRacial = racial;
        }
    }
}
