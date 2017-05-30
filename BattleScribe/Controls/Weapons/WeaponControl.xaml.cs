using BattleScribe.Forms;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BattleScribe.Classes;

namespace BattleScribe.Controls.Weapons
{
    public partial class WeaponControl : UserControl
    {
        private PlayScreen play;
        private BattleScribe.Classes.Items.Weapon w;
        private Character c;
        private Brush standardBackground;

        private string mod;
        private int toHit;


        public WeaponControl()
        {
            InitializeComponent();
        }

        public WeaponControl(BattleScribe.Classes.Items.Weapon w, PlayScreen play, Character c)
        {
            InitializeComponent();

            this.play = play;
            this.w = w;
            this.c = c;
            this.standardBackground = this.Background;

            lbName.Content = w.GetName();
            lbDamage.Content = w.GetDamage();
            lbDamageType.Content = w.GetBaseDamageType();

            mod = w.GetModifier();

            if (mod == "FIN")
            {
                int STR = c.GetModifier("STR");
                int DEX = c.GetModifier("DEX");

                if (STR >= DEX)
                {
                    mod = "STR";
                }
                else
                {
                    mod = "DEX";
                }
            }

            toHit = c.GetModifier(mod) + c.GetProfiencyBonus();
            lbToHit.Content = "Hit: " + toHit.ToString();
        }

        private void UserControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            play.ChooseWeapon(this);
        }

        public void Attack()
        {
            string amount = string.Empty;
            string sides = string.Empty;

            int amountNumb = 0;
            int sidesNumb = 0;

            string damage = w.GetDamage();

            bool pastDice = false;

            for (int i = 0; i < damage.Length; i++)
            {
                if (!pastDice)
                {
                    if (damage[i] != 'd')
                    {
                        amount += damage[i];
                    }
                    else
                    {
                        pastDice = true;
                    }
                }
                else
                {
                    sides += damage[i];
                }
            }

            try
            {
                amountNumb = Convert.ToInt32(amount);
                sidesNumb = Convert.ToInt32(sides);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid damage conversion.");
            }

            play.log.Write("To hit: " + DiceThrower.ThrowDice(0, 20, toHit));
            play.log.Write("Damage: " + (DiceThrower.ThrowDice(amountNumb - 1, sidesNumb, c.GetModifier(mod)) + 1) + " " + w.GetBaseDamageType());

            if (w.GetBonusDamage() != 0)
            {
                play.log.Write("Bonus: " + w.GetBonusDamage() + " " + w.GetBonusDamageType());
            }
        }

        public void Highlight(bool target)
        {
            if (target)
            {
                this.Background = new SolidColorBrush(System.Windows.Media.Colors.Aquamarine);
            }
            else
            {
                this.Background = standardBackground;
            }
        }

        public BattleScribe.Classes.Items.Weapon GetWeapon()
        {
            return this.w;
        }
    }
}
