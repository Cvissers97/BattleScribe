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

namespace BattleScribe.Forms
{
    /// <summary>
    /// Interaction logic for CreationWizardTemp1.xaml
    /// </summary>
    public partial class CreationWizardTemp1 : Window
    {
        public CreationWizardTemp1()
        {
            InitializeComponent();

            //replace arcana with db of skills
            CheckBox check = new CheckBox();
            check.Content = "Arcana";
            check.Name = "cb" + "Arcana";
            panelSkills.Children.Add(check);

            CheckBox check2 = new CheckBox();
            check2.Content = "Abyssal";
            check2.Name = "cbAbyssal";
            panelLanguages.Children.Add(check2);
        }
    }
}
