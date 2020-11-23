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

namespace Mastermind
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Grid grille;
        private Button[,] buttons;

        public MainWindow()
        {
            InitializeComponent();

            grille = new Grid();
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(380);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(50);
            grille.RowDefinitions.Add(gridRow1);
            grille.RowDefinitions.Add(gridRow2);
            this.Content = grille;

            buttons = new Button[4, 10];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Margin = new Thickness(5+32 * i, 20+32 * j, 0, 0);
                    buttons[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[i, j].VerticalAlignment = VerticalAlignment.Top;
                    buttons[i, j].Width = 32;
                    buttons[i, j].Height = 32;

                    ImageBrush imgB = new ImageBrush();
                    BitmapImage img = new BitmapImage(new Uri("pack://application:,,,/Images/trou.gif"));
                    imgB.ImageSource = img;
                    buttons[i, j].Background = imgB;
                    Grid.SetRow(this.buttons[i, j], 0);
                    this.grille.Children.Add(this.buttons[i, j]);

                }
            }
        }

        public Grid Grille { get => grille; set => grille = value; }
      
    }
}
