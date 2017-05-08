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
    /// Interaction logic for CharacterCreationWizard.xaml
    /// </summary>
    public partial class CharacterCreationWizard : Window
    {
        // Screen count total of 3, starting at 1
        // 1 = Personal, 2 = Statistics, 3 = Magic
        byte screen;

        public CharacterCreationWizard()
        {
            InitializeComponent();
            screen = 1;
            UpdateScreen();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            screen++;
            UpdateScreen();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            screen--;
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            MessageBox.Show(screen.ToString());
            btnFinish.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;

            if ((screen - 1) == 0)
            {
                btnBack.IsEnabled = false;
            }
            else
            {
                btnBack.IsEnabled = true;
            }

            if ((screen + 1) == 4)
            {
                btnNext.IsEnabled = false;
                btnNext.Visibility = Visibility.Hidden;
                btnFinish.Visibility = Visibility.Visible;
            }
            else
            {
                btnNext.IsEnabled = true;
            }

            //Make everything invisible. The choose what to show.
            // PERSONAL
            lbName.Visibility = Visibility.Hidden;
            lbAge.Visibility = Visibility.Hidden;
            lbSize.Visibility = Visibility.Hidden;
            lbGender.Visibility = Visibility.Hidden;
            chMale.Visibility = Visibility.Hidden;
            chFemale.Visibility = Visibility.Hidden;
            imgChar.Visibility = Visibility.Hidden;
            btnUpload.Visibility = Visibility.Hidden;
            lbAppearance.Visibility = Visibility.Hidden;
            rtbAppearance.Visibility = Visibility.Hidden;
            tbName.Visibility = Visibility.Hidden;
            tbAge.Visibility = Visibility.Hidden;
            tbSize.Visibility = Visibility.Hidden;
            lbAgeExtra.Visibility = Visibility.Hidden;
            lbSizeExtra.Visibility = Visibility.Hidden;
            lbTitle.Visibility = Visibility.Hidden;
            lbAlignment.Visibility = Visibility.Hidden;
            tbTitle.Visibility = Visibility.Hidden;
            tbAlignment.Visibility = Visibility.Hidden;
            lbPersonality.Visibility = Visibility.Hidden;
            rtbPersonality.Visibility = Visibility.Hidden;
            lbFlaws.Visibility = Visibility.Hidden;
            rtbFlaws.Visibility = Visibility.Hidden;
            lbIdeals.Visibility = Visibility.Hidden;
            rtbIdeals.Visibility = Visibility.Hidden;
            lbBonds.Visibility = Visibility.Hidden;
            rtbBonds.Visibility = Visibility.Hidden;
            lbBackstory.Visibility = Visibility.Hidden;
            rtbBackstory.Visibility = Visibility.Hidden;

            // STATISTICS
            lbRace.Visibility = Visibility.Hidden;
            lbClass.Visibility = Visibility.Hidden;
            cbRaces.Visibility = Visibility.Hidden;
            cbClasses.Visibility = Visibility.Hidden;
            lbSTR.Visibility = Visibility.Hidden;
            lbDEX.Visibility = Visibility.Hidden;
            lbCON.Visibility = Visibility.Hidden;
            lbINT.Visibility = Visibility.Hidden;
            lbWIS.Visibility = Visibility.Hidden;
            lbCHA.Visibility = Visibility.Hidden;
            btnPlusSTR.Visibility = Visibility.Hidden;
            btnMinSTR.Visibility = Visibility.Hidden;
            btnPlusDEX.Visibility = Visibility.Hidden;
            btnMinDEX.Visibility = Visibility.Hidden;
            btnPlusCON.Visibility = Visibility.Hidden;
            btnMinCON.Visibility = Visibility.Hidden;
            btnPlusINT.Visibility = Visibility.Hidden;
            btnMinINT.Visibility = Visibility.Hidden;
            btnPlusWIS.Visibility = Visibility.Hidden;
            btnMinWIS.Visibility = Visibility.Hidden;
            btnPlusCHA.Visibility = Visibility.Hidden;
            btnMinCHA.Visibility = Visibility.Hidden;
            lbPoints.Visibility = Visibility.Hidden;
            lbBackground.Visibility = Visibility.Hidden;
            cbBackgrounds.Visibility = Visibility.Hidden;
            lbEquipment.Visibility = Visibility.Hidden;
            rbEquip1A.Visibility = Visibility.Hidden;
            rbEquip2A.Visibility = Visibility.Hidden;
            rbEquip3A.Visibility = Visibility.Hidden;
            rbEquip1B.Visibility = Visibility.Hidden;
            rbEquip2B.Visibility = Visibility.Hidden;
            rbEquip3B.Visibility = Visibility.Hidden;
            cbStartMoney.Visibility = Visibility.Hidden;
            panelSkills.Visibility = Visibility.Hidden;
            lbSkills.Visibility = Visibility.Hidden;
            lbMiscProf.Visibility = Visibility.Hidden;
            rtbMiscProf.Visibility = Visibility.Hidden;
            panelLanguages.Visibility = Visibility.Hidden;
            lbLanguage.Visibility = Visibility.Hidden;

            // MAGIC
            lbCantrip.Visibility = Visibility.Hidden;
            panelCantrips.Visibility = Visibility.Hidden;
            lbKnownSpells.Visibility = Visibility.Hidden;
            panelKnownSpells.Visibility = Visibility.Hidden;
            panelPrepSpells.Visibility = Visibility.Hidden;
            lbPrepSpells.Visibility = Visibility.Hidden;
            btnPrepare.Visibility = Visibility.Hidden;
            btnUnprepare.Visibility = Visibility.Hidden;

            switch (screen)
            {
                case 1:
            // Show all contents of the 'personal' screen.
            lbName.Visibility = Visibility.Visible;
            lbAge.Visibility = Visibility.Visible;
            lbSize.Visibility = Visibility.Visible;
            lbGender.Visibility = Visibility.Visible;
            chMale.Visibility = Visibility.Visible;
            chFemale.Visibility = Visibility.Visible;
            imgChar.Visibility = Visibility.Visible;
            btnUpload.Visibility = Visibility.Visible;
            lbAppearance.Visibility = Visibility.Visible;
            rtbAppearance.Visibility = Visibility.Visible;
            tbName.Visibility = Visibility.Visible;
            tbAge.Visibility = Visibility.Visible;
            tbSize.Visibility = Visibility.Visible;
            lbAgeExtra.Visibility = Visibility.Visible;
            lbSizeExtra.Visibility = Visibility.Visible;
            lbTitle.Visibility = Visibility.Visible;
            lbAlignment.Visibility = Visibility.Visible;
            tbTitle.Visibility = Visibility.Visible;
            tbAlignment.Visibility = Visibility.Visible;
            lbPersonality.Visibility = Visibility.Visible;
            rtbPersonality.Visibility = Visibility.Visible;
            lbFlaws.Visibility = Visibility.Visible;
            rtbFlaws.Visibility = Visibility.Visible;
            lbIdeals.Visibility = Visibility.Visible;
            rtbIdeals.Visibility = Visibility.Visible;
            lbBonds.Visibility = Visibility.Visible;
            rtbBonds.Visibility = Visibility.Visible;
            lbBackstory.Visibility = Visibility.Visible;
            rtbBackstory.Visibility = Visibility.Visible;
                    break;

                case 2:
            // Show all contents of the 'statistics' screen.
            lbRace.Visibility = Visibility.Visible;
            lbClass.Visibility = Visibility.Visible;
            cbRaces.Visibility = Visibility.Visible;
            cbClasses.Visibility = Visibility.Visible;
            lbSTR.Visibility = Visibility.Visible;
            lbDEX.Visibility = Visibility.Visible;
            lbCON.Visibility = Visibility.Visible;
            lbINT.Visibility = Visibility.Visible;
            lbWIS.Visibility = Visibility.Visible;
            lbCHA.Visibility = Visibility.Visible;
            btnPlusSTR.Visibility = Visibility.Visible;
            btnMinSTR.Visibility = Visibility.Visible;
            btnPlusDEX.Visibility = Visibility.Visible;
            btnMinDEX.Visibility = Visibility.Visible;
            btnPlusCON.Visibility = Visibility.Visible;
            btnMinCON.Visibility = Visibility.Visible;
            btnPlusINT.Visibility = Visibility.Visible;
            btnMinINT.Visibility = Visibility.Visible;
            btnPlusWIS.Visibility = Visibility.Visible;
            btnMinWIS.Visibility = Visibility.Visible;
            btnPlusCHA.Visibility = Visibility.Visible;
            btnMinCHA.Visibility = Visibility.Visible;
            lbPoints.Visibility = Visibility.Visible;
            lbBackground.Visibility = Visibility.Visible;
            cbBackgrounds.Visibility = Visibility.Visible;
            lbEquipment.Visibility = Visibility.Visible;
            rbEquip1A.Visibility = Visibility.Visible;
            rbEquip2A.Visibility = Visibility.Visible;
            rbEquip3A.Visibility = Visibility.Visible;
            rbEquip1B.Visibility = Visibility.Visible;
            rbEquip2B.Visibility = Visibility.Visible;
            rbEquip3B.Visibility = Visibility.Visible;
            cbStartMoney.Visibility = Visibility.Visible;
            panelSkills.Visibility = Visibility.Visible;
            lbSkills.Visibility = Visibility.Visible;
            lbMiscProf.Visibility = Visibility.Visible;
            rtbMiscProf.Visibility = Visibility.Visible;
            panelLanguages.Visibility = Visibility.Visible;
            lbLanguage.Visibility = Visibility.Visible;
                    break;
                    
                case 3:
            // Show all contents of the 'magic' screen.
            lbCantrip.Visibility = Visibility.Visible;
            panelCantrips.Visibility = Visibility.Visible;
            lbKnownSpells.Visibility = Visibility.Visible;
            panelKnownSpells.Visibility = Visibility.Visible;
            panelPrepSpells.Visibility = Visibility.Visible;
            lbPrepSpells.Visibility = Visibility.Visible;
            btnPrepare.Visibility = Visibility.Visible;
            btnUnprepare.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
