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

namespace BattleScribe.Controls.Char
{
    /// <summary>
    /// Interaction logic for MainScreenCharacter.xaml
    /// </summary>
    public partial class MainScreenCharacter : UserControl
    {
        public Classes.Character character;
        
        public MainScreenCharacter()
        {
            InitializeComponent();
        }

        public MainScreenCharacter(Classes.Character c, List<CharacterClass> cClass)
        {
            character = c;
            InitializeComponent();

            using(MemoryStream ms = new MemoryStream(c.GetImage()))
            {
                BitmapDecoder decoder = BitmapDecoder.Create(ms,
                BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                image.Source = decoder.Frames[0];
            }
            lblName.Content = c.GetName();

            foreach(CharacterClass cl in cClass)
            {
                if(cl.GetId() == c.GetClass())
                {
                    lblClass.Content = cl.GetName();
                }
            }

        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BattleScribe.Forms.DetailScreen newScreen = new Forms.DetailScreen(character);

            newScreen.Show();
            Window parentWindow = Application.Current.MainWindow;
            parentWindow.Close();
            
        }
    }
}
