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
using BattleScribe.Forms.Pop_ups.Items;

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

            string damageDisplay = string.Empty;

            if (w.GetDamage() != "0")
            {
                damageDisplay += w.GetDamage();
            }

            if (w.GetDamage2() != "0")
            {
                damageDisplay += " + " + w.GetDamage2();
            }

            if (w.GetBonusDamage() != 0)
            {
                damageDisplay += " + " + w.GetBonusDamage();
            }

            lbDamage.Content = damageDisplay;
            //lbDamageType.Content = w.GetBaseDamageType();

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

            string amount2 = string.Empty;
            string sides2 = string.Empty;

            int amountNumb = 0;
            int sidesNumb = 0;

            int amountNumb2 = 0;
            int sidesNumb2 = 0;

            string damage = w.GetDamage();

            bool pastDice = false;
            bool secondDice = false;

            if (damage == "1")
            {
                play.log.Write("Damage: " + damage + " " + w.GetBaseDamageType());
                play.log.Write("To hit: " + DiceThrower.RollToHit(toHit));
                play.log.InputSpace();
            }
            else
            {
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

                pastDice = false;

                damage = w.GetDamage2();

                if (damage != "0" && damage != string.Empty && damage != null)
                {
                    secondDice = true;

                    for (int i = 0; i < damage.Length; i++)
                    {
                        if (!pastDice)
                        {
                            if (damage[i] != 'd')
                            {
                                amount2 += damage[i];
                            }
                            else
                            {
                                pastDice = true;
                            }
                        }
                        else
                        {
                            sides2 += damage[i];
                        }
                    }
                }

                try
                {
                    amountNumb = Convert.ToInt32(amount);
                    sidesNumb = Convert.ToInt32(sides);

                    if (secondDice)
                    {
                        amountNumb2 = Convert.ToInt32(amount2);
                        sidesNumb2 = Convert.ToInt32(sides2);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid damage conversion.");
                }

                string toHitMessage = DiceThrower.RollToHit(toHit);
                int criticalDice = 20 + toHit;

                // Critical hits
                if (toHitMessage == ("Critical " + criticalDice))
                {
                    amountNumb++;
                }

                if (w.GetBonusDamage() != 0)
                {
                    play.log.Write("Bonus: " + w.GetBonusDamage() + " " + w.GetBonusDamageType());
                }

                if (secondDice)
                {
                    play.log.Write("+ " + (DiceThrower.RollDamage(amountNumb2, sidesNumb2, 0)) + " " + w.GetBaseDamage2());
                }

                play.log.Write("Damage: " + (DiceThrower.RollDamage(amountNumb, sidesNumb, c.GetModifier(mod))) + " " + w.GetBaseDamageType());
                play.log.Write("To hit: " + toHitMessage);
                play.log.InputSpace();
            }
        }

        public void Highlight(bool target)
        {
            if (target)
            {
                this.Background = new SolidColorBrush(System.Windows.Media.Colors.Indigo);
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

        private void Grid_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewWeapon view = new ViewWeapon(w);
            view.Show();
        }
    }
}
