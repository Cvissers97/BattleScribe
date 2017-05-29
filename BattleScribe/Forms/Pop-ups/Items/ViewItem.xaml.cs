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
using BattleScribe.Classes.Items;

namespace BattleScribe.Forms.Pop_ups.Items
{
    /// <summary>
    /// Interaction logic for ViewItem.xaml
    /// </summary>
    public partial class ViewItem : Window
    {
        public ViewItem()
        {
            InitializeComponent();
        }

        public ViewItem(Item i)
        {
            InitializeComponent();
            tbName.Text = i.GetName();
            tbType.Text = i.GetItemType();
            rtbDescription.Document.Blocks.Clear();
            rtbDescription.Document.Blocks.Add(new Paragraph(new Run(i.GetDescription())));
            tbWeight.Text = i.GetWeight();
        }
    }
}
