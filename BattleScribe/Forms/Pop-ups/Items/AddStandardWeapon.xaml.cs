using BattleScribe.Classes;
using BattleScribe.Classes.Items;
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

namespace BattleScribe.Forms.Pop_ups.Items
{
    /// <summary>
    /// Interaction logic for AddStandardWeapon.xaml
    /// </summary>
    public partial class AddStandardWeapon : Window
    {
        private int characterId;
        private DetailScreen screen;
        private DbHandler db;
        private List<Weapon> weaponList;
        private Weapon Weapon;

        public AddStandardWeapon()
        {
            InitializeComponent();
        }

        public AddStandardWeapon(int id)
        {
            db = new DbHandler();
            InitializeComponent();

            this.characterId = id;
        }

        public AddStandardWeapon(DetailScreen screen)
        {
            db = new DbHandler();
            InitializeComponent();
            this.screen = screen;
            Init();
        }

        public void Init()
        {
            weaponList = db.GetAllWeapons();

            foreach (Item i in weaponList)
            {
                cbName.Items.Add(i.GetName());
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //screen.AddItemToInventory(Weapon);
        }

        private void CbName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Weapon w in weaponList)
            {
                if (w.GetName() == (string)cbName.SelectedItem)
                {
                    tbDamage.Text = w.GetDamage();
                    tbAttackType.Text = w.GetBaseDamageType();
                    tbType.Text = w.GetItemType();
                    tbWeight.Text = w.GetWeight();
                    Weapon = w;
                    break;
                }
            }
        }
    }
}
