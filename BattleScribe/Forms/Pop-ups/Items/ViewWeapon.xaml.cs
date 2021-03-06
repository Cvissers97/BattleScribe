﻿using BattleScribe.Classes.Items;
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
    public partial class ViewWeapon : Window
    {
        public ViewWeapon()
        {
            InitializeComponent();
        }

        public ViewWeapon(Weapon w)
        {
            InitializeComponent();

            tbName.Text = w.GetName();
            rtbDescription.Document.Blocks.Clear();
            rtbDescription.Document.Blocks.Add(new Paragraph(new Run(w.GetDescription())));
            tbWeight.Text = w.GetWeight();
            chkAttune.IsChecked = w.GetAttunement();

            string damage = string.Empty;

            if (w.GetDamage() != "0")
            {
                damage += w.GetDamage() + " " + w.GetBaseDamageType();
            }

            if (w.GetDamage2() != "0")
            {
                damage += " + " + w.GetDamage2() + " " + w.GetBaseDamage2();
            }

            if (w.GetBonusDamage() != 0)
            {
                damage += " + " + w.GetBonusDamage() + " " + w.GetBonusDamageType();
            }

            tbDamage.Text = damage;
        }
    }
}
