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
    /// Interaction logic for ViewFeature.xaml
    /// </summary>
    public partial class ViewFeature : Window
    {
        public ViewFeature()
        {
            InitializeComponent();
        }

        public ViewFeature(string name, string description)
        {
            InitializeComponent();

            tbName.Text = name;
            rtbDesc.Document.Blocks.Clear();
            rtbDesc.Document.Blocks.Add(new Paragraph(new Run(description)));
        }
    }
}
