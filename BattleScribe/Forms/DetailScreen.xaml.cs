﻿using BattleScribe.Classes;
using BattleScribe.Controls.Feats;
using BattleScribe.Forms.Pop_ups;
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
    /// Interaction logic for DetailScreen.xaml
    /// </summary>
    public partial class DetailScreen : Window
    {
        private int curHPNum;
        private List<Feat> feats;

        public DetailScreen()
        {
            InitializeComponent();

            feats = new List<Feat>();
            curHPNum = 0;
            UpdateFeatList();
        }

        private void btnPlusHP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                curHPNum = Convert.ToInt16(tbCurHP.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                throw;
            }

            AddHealth add = new AddHealth(curHPNum, 3, "Wizard", this);
            add.Show();
        }

        public void SetNewHealth(int HP)
        {
            tbCurHP.Text = HP.ToString();
        }

        private void btnAddFeat_Click(object sender, RoutedEventArgs e)
        {
            AddFeat add = new AddFeat(this);
            add.Show();
        }

        public void AddNewFeat(Feat feat)
        {
            feats.Add(feat);
            UpdateFeatList();
        }

        private void UpdateFeatList()
        {
            //Connect to the character database later, fill in dynamically

            stackFeats.Children.Clear();

            foreach (Feat f in feats)
            {
                //Make new entries for the scrollviewer
                FeatControl feat = new FeatControl(f.id);
                feat.lbFeatName.Content = f.GetName();
                stackFeats.Children.Add(feat);
            }
        }

        private void btnRemoveFeat_Click(object sender, RoutedEventArgs e)
        {
            // List of Feat IDs that need to be removed.
            List<int> remIdList = new List<int>();
            List<Feat> newFeats = new List<Feat>();

            foreach (Feat f in feats)
            {
                newFeats.Add(f);
            }

            foreach (FeatControl featCon in stackFeats.Children)
            {
                if (featCon.GetSelect())
                {
                    remIdList.Add(featCon.GetID());
                }
            }

            foreach (int i in remIdList)
            {
                foreach (Feat f in feats)
                {
                    if (f.id == i)
                    {
                        newFeats.Remove(f);
                    }
                }
            }

            feats = newFeats;
            UpdateFeatList();
        }
    }
}