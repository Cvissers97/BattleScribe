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
using BattleScribe.Classes;

namespace BattleScribe.Forms.Pop_ups.Items
{
    /// <summary>
    /// Interaction logic for AddStandardArmour.xaml
    /// </summary>
    public partial class AddStandardArmour : Window
    {
        private int characterId;
        private DetailScreen screen;
        private Armour armour;
        private List<Armour> armourList;
        private DbHandler db;

        public AddStandardArmour()
        {
            InitializeComponent();
        }

        public AddStandardArmour(int id)
        {
            InitializeComponent();

            this.characterId = id;
        }

        public AddStandardArmour(DetailScreen screen)
        {
            db = new DbHandler();

            armourList = db.GetAllArmour(); 
            InitializeComponent();
            this.screen = screen;
            foreach (Armour a in armourList)
            {
                cbArmourName.Items.Add(a.GetName());
            }
        }

        private void CbArmourName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Armour a in armourList)
            {
                if (a.GetName() == (string)cbArmourName.SelectedItem)
                {
                    tbMod.Text = a.GetModifier();
                    tbStrength.Text = a.GetStrReq().ToString();
                    tbType.Text = a.GetItemType();
                    chkStealth.IsChecked = a.GetStealthDis();
                    tbCost.Text = a.GetValue();
                    tbWeight.Text = a.GetWeight();
                    armour = a;
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //screen.AddItemToInventory(armour);
        }
    }
}
