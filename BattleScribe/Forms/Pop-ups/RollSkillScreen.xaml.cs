﻿using System;
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

        public RollSkillScreen()
        {
            InitializeComponent();
        }
    }
}