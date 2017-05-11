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
    /// Interaction logic for AddEXP.xaml
    /// </summary>
    public partial class AddEXP : Window
    {
        private DetailScreen detail;

        public AddEXP()
        {
            InitializeComponent();
        }

        public AddEXP(DetailScreen detail)
        {
            InitializeComponent();
            this.detail = detail;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Add experience points
        }
    }
}
