using BattleScribe.Classes;
using BattleScribe.Controls.Skills;
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
    /// Interaction logic for RollSkillScreen.xaml
    /// </summary>
    public partial class RollSkillScreen : Window
    {
        // Implement this regex for the bonus textbox
        // Make sure it can be a negative number
        // Regex:  ^-?[0-9]\d*(\.\d+)?$

        Character c;
        PlayScreen p;

        public RollSkillScreen()
        {
            InitializeComponent();
        }

        public RollSkillScreen(Character c, PlayScreen play)
        {
            InitializeComponent();
            this.c = c;
            SkillControl skill;
            this.p = play;

            foreach (string s in c.SkillsList())
            {
                skill = new SkillControl(c.GetModifier(s), this);
                skill.lbSkill.Content = s;
                stackSkills.Children.Add(skill);
            }
        }

        private void tbBonus_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbBonus.Text, @"^[-+]?[0-9]*\.?[0-9]+$"))
            {
                tbBonus.Text = string.Empty;
            }
        }

        public void Roll(int mod)
        {
            int result;

            bool adv = rbAdvantage.IsChecked.Value;
            bool dis = rbDisadvantage.IsChecked.Value;

            if (adv)
            {
                result = DiceThrower.ThrowDieAdvantage(20, mod, true);
            }
            else if (dis)
            {
                result = DiceThrower.ThrowDieAdvantage(20, mod, false);
            }
            else
            {
                result = DiceThrower.ThrowDice(0, 20, mod);
            }

            if (tbBonus.Text != "")
            {
                result += Convert.ToInt32(tbBonus.Text);
            }

            List<int> temp = new List<int>();
            temp.Add(result);
            p.log.DisplayResult(temp);
            this.Close();
        }
    }
}
