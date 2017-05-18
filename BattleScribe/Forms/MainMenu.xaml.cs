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

        public MainMenu()
        {
            db = new DbHandler();
            c = new List<Character>();
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            c = db.GetCharacterForMain();
            cClass = db.GetClasses();

            foreach(Character cha in c)
            {
                MainScreenCharacter temp = new MainScreenCharacter(cha, cClass);
                stack.Children.Add(temp);
            }
        }

    }
}
