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
using BattleScribe.Classes;
using BattleScribe.Controls.Char;

namespace BattleScribe.Forms
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public DbHandler db;
        public List<Character> c;
        public List<CharacterClass> cClass;

        bool deleteMode;

        public MainMenu()
        {
            db = new DbHandler();
            c = new List<Character>();
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            stack.Children.Clear();

            c = db.GetCharacterForMain();
            cClass = db.GetClasses();

            deleteMode = false;

            foreach(Character cha in c)
            {
                MainScreenCharacter temp = new MainScreenCharacter(this, cha, cClass, deleteMode);
                stack.Children.Add(temp);
            }

        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            CharacterCreationWizard wizard = new CharacterCreationWizard();
            wizard.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteMode = !deleteMode;

            stack.Children.Clear();

            foreach (Character cha in c)
            {
                MainScreenCharacter temp = new MainScreenCharacter(this, cha, cClass, deleteMode);
                stack.Children.Add(temp);
            }
        }
    }
}
