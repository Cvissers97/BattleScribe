using BattleScribe.Classes;
using BattleScribe.Classes.Items;
using BattleScribe.Controls;
using BattleScribe.Controls.Items;
using BattleScribe.Forms;
using BattleScribe.Forms.Pop_ups;
using BattleScribe.Forms.Pop_ups.Items;
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
    public partial class PlayScreen : Window
    {
        private Character c;
        public LogHandler log;
        private DbHandler db;

        public PlayScreen()
        {
            InitializeComponent();
            InitialiseBase();
        }

        public PlayScreen(Character c)
        {
            InitializeComponent();
            InitialiseBase();

            this.c = c;
            lbHealth.Content = c.GetMaxHealth();
        }

        private void InitialiseBase()
        {
            UpdateInventory();
            UpdateHealth();
            UpdateStats();

            log = new LogHandler(listAction);
            db = new DbHandler();
        }

        public void UpdateStats()
        {
            // Gets the stats from the character object and calculates the approperate modifiers

            lbSTRMod.Content = c.CalcMod("STR", 0);
            lbSTRStat.Content = c.GetStr();

            lbDEXMod.Content = c.CalcMod("DEX", 0);
            lbDEXStat.Content = c.GetDex();

            lbCONMod.Content = c.CalcMod("CON", 0);
            lbCONStat.Content = c.GetCon();

            lbINTMod.Content = c.CalcMod("INT", 0);
            lbINTStat.Content = c.GetInt();

            lbWISMod.Content = c.CalcMod("WIS", 0);
            lbWISStat.Content = c.GetWis();

            lbCHAMod.Content = c.CalcMod("CHA", 0);
            lbCHAStat.Content = c.GetCha();
        }

        public void UpdateInspiration()
        {
            if (c.GetInspiration())
            {
                //imgInsp.Source = "/BattleScribe;component/Resources/Icons/Buttons/Inspiration_Button.png";
            }
            else
            {

            }
        }

        public void UpdateHealth()
        {
            lbHealth.Content = "HP: " + c.GetCurrentHealth();
        }
        private void UpdateInventory()
        {
            stackInventory.Children.Clear();
            ItemLegend leg = new ItemLegend();
            stackInventory.Children.Add(leg);
            //Read out all items in the character's inventory (Armour, Weapon, Item)
            //Turn all of them into stackpanels

            //Temp character for inventory testing. Write proper getters/setters for inventory later
            c = new Character(13);
            Weapon sword = new Weapon(30, "Flamesword", "Hot", 1, 4, "Weapon", true, true, 10.5, "DEX", 10, "Slashing", "Fire");
            c.AddWeapon(sword);
            Item ring = new Item(20, "Ring", "Fancy ring", "Jewelry", false, true, 0.5);
            c.AddItem(ring);
            Armour chainmail = new Armour(2, "Chainmail", "Mail of chains", "Armour", true, true, 35, true, 10, 3, "STR");
            c.AddArmour(chainmail);

            ItemControl temp;
            foreach (Weapon w in c.GetAllWeapons())
            {
                temp = new ItemControl(w.GetID());
                temp.lbName.Content = w.GetName();
                temp.lbType.Content = w.GetType();
                temp.lbProficiency.Content = w.GetProficient();
                temp.lbValue.Content = w.GetValue();
                temp.lbWeight.Content = w.GetWeight();
                temp.lbAttune.Content = w.GetAttunement();
                stackInventory.Children.Add(temp);
            }

            foreach (Item i in c.GetAllItems())
            {
                temp = new ItemControl(i.GetID());
                temp.lbName.Content = i.GetName();
                temp.lbType.Content = i.GetItemType();
                temp.lbProficiency.Content = i.GetProficient();
                temp.lbValue.Content = i.GetValue();
                temp.lbWeight.Content = i.GetWeight();
                temp.lbAttune.Content = i.GetAttunement();
                stackInventory.Children.Add(temp);
            }

            foreach (Armour a in c.GetAllArmours())
            {
                temp = new ItemControl(a.GetID());
                temp.lbName.Content = a.GetName();
                temp.lbType.Content = a.GetItemType();
                temp.lbProficiency.Content = a.GetProficient();
                temp.lbValue.Content = a.GetValue();
                temp.lbWeight.Content = a.GetWeight();
                temp.lbAttune.Content = a.GetAttunement();
                stackInventory.Children.Add(temp);
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            ItemChoice i = new ItemChoice(c.GetID());
            i.Show();
        }
        
        private void btnRollCheck_Click(object sender, RoutedEventArgs e)
        {
            RollSkillScreen r = new RollSkillScreen(c, this);
            r.Show();
        }

        private void btnHeart_Click(object sender, RoutedEventArgs e)
        {
            if (c.GetCurrentHealth() - 1 != -1)
            {
                c.SetCurrentHealth(c.GetCurrentHealth() - 1);
                UpdateHealth();
            }
        }

        private void btnInspiration_Click(object sender, RoutedEventArgs e)
        {
            c.ToggleInspiration();
            
        }

        private void btnInitiative_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHitDie_Click(object sender, RoutedEventArgs e)
        {
            int hitDice;
            hitDice = db.GetHitDiceByClass(c.GetClassName());
        }

        private void btnHeart_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void menuHeal_Click(object sender, RoutedEventArgs e)
        {
            AddNumber a = new AddNumber(this, "HEAL");
            a.Show();
        }

        private void menuDeath_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void menuHurt_Click(object sender, RoutedEventArgs e)
        {
            AddNumber a = new AddNumber(this, "DAMAGE");
            a.Show();
        }

        public Character GetCharacter()
        {
            return c;
        }
    }
}
