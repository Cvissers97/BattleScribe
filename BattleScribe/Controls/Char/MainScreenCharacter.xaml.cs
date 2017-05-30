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
using System.IO;
using temp = System.Drawing;
using BattleScribe.Classes;
using BattleScribe.Forms;

namespace BattleScribe.Controls.Char
{
    public partial class MainScreenCharacter : UserControl
    {
        public Classes.Character character;
        public Classes.DbHandler db;

        private MainMenu menu;
        
        public MainScreenCharacter()
        {
            InitializeComponent();
        }

        public MainScreenCharacter(MainMenu menu, Classes.Character c, List<CharacterClass> cClass, bool delete)
        {
            this.menu = menu;
            character = c;
            InitializeComponent();

            if (c.GetImage().Count() > 1)
            {
                using (MemoryStream ms = new MemoryStream(c.GetImage()))
                {
                    BitmapDecoder decoder = BitmapDecoder.Create(ms,
                    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                    image.Source = decoder.Frames[0];
                }
            }


            lblName.Content = c.GetName();

            foreach(CharacterClass cl in cClass)
            {
                if(cl.GetId() == c.GetClass())
                {
                    lblClass.Content = cl.GetName();
                }
            }
            lblLevel.Content += c.GetLevel().ToString();

            if (!delete)
            {
                btnDelete.Visibility = Visibility.Hidden;
            }
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BattleScribe.Forms.DetailScreen newScreen = new Forms.DetailScreen(character, image);

            newScreen.Show();
            Window parentWindow = Application.Current.MainWindow;
            parentWindow.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Delete " + lblName.Content + " ?", "Deleting Character", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                db = new DbHandler();
                db.DeleteCharacter(character.GetID());
                menu.Init();
            }
        }
    }
}
