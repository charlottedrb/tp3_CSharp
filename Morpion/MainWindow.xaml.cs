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

namespace Morpion
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MorpionJeu morpion = new MorpionJeu(new Joueur("Joueur1"), new Joueur("Joueur2"));
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aProposDialog(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Made with love");
        }

        private string Clicked()
        {
            if (morpion.JoueurEnCours == 2)
            {
                Joueur1.Background = Brushes.Red;
                Joueur2.Background = Brushes.White;
                return "X";
            }
            else
            {
                Joueur1.Background = Brushes.White;
                Joueur2.Background = Brushes.Red;
                return "O";
            }
        }

        private void EndGame()
        {
            Object obj = morpion.Gagne();
            if (obj != null)
            {
                Joueur gagnant = (Joueur)obj;

                string text = "Le gagnant est le ";
                if (gagnant.Nom == "Joueur1")
                {
                    text += "Joueur 1";
                }

                else
                {
                    text += "Joueur 2";
                }
                MessageBox.Show(text);
            }
        }

        private void ClickCase1(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(0, 0);
            Case1.Content = Clicked();
            Case1.IsEnabled = false;
            EndGame();
        }

        private void ClickCase2(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(1, 0);
            Case2.Content = Clicked();
            Case2.IsEnabled = false;
            EndGame();
        }

        private void ClickCase3(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(2, 0);
            Case3.Content = Clicked();
            Case3.IsEnabled = false;
            EndGame();
        }

        private void ClickCase4(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(0, 1);
            Case4.Content = Clicked();
            Case4.IsEnabled = false;
            EndGame();
        }

        private void ClickCase5(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(1, 1);
            Case5.Content = Clicked();
            Case5.IsEnabled = false;
            EndGame();
        }

        private void ClickCase6(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(2, 1);
            Case6.Content = Clicked();
            Case6.IsEnabled = false;
            EndGame();
        }

        private void ClickCase7(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(0, 2);
            Case7.Content = Clicked();
            Case7.IsEnabled = false;
            EndGame();
        }

        private void ClickCase8(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(1, 2);
            Case8.Content = Clicked();
            Case8.IsEnabled = false;
            EndGame();
        }

        private void ClickCase9(object sender, RoutedEventArgs e)
        {
            morpion.JoueCase(2, 2);
            Case9.Content = Clicked();
            Case9.IsEnabled = false;
            EndGame();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            morpion.ReinitGrille();
            new MorpionJeu(new Joueur("Joueur1"), new Joueur("Joueur2"));
        }
    }
}
