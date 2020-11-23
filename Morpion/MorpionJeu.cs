using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class MorpionJeu
    {
        private Joueur[] lesJoueurs;
        private int joueurEnCours;

        public int[,] Grille { get; set; }

        public Joueur[] LesJoueurs
        {
            get
            {
                return this.lesJoueurs;
            }

            set
            {
                this.lesJoueurs = value;
            }
        }

        public int JoueurEnCours
        {
            get
            {
                return this.joueurEnCours;
            }

            set
            {
                this.joueurEnCours = value;
            }
        }

        public void JoueCase(int x, int y)
        {
            this.Grille[x, y] = this.JoueurEnCours;
            this.JoueurEnCours = (this.JoueurEnCours == 1 ? 2 : 1);
        }

        public MorpionJeu(Joueur j1, Joueur j2)
        {
            this.LesJoueurs = new Joueur[2];

            this.LesJoueurs[0] = j1;
            this.LesJoueurs[1] = j2;
            this.JoueurEnCours = 1;


            Grille = new int[3, 3];
        }
        public MorpionJeu() : this(new Joueur("Joueur 1"), new Joueur("Joueur 2"))
        { }
        public bool GrillePleine()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Grille[i, j] == 0)
                        return false;
            return true;
        }

        public Joueur Gagne()
        {

            int numJoueurGagnant = -1;
            //verif des lignes
            for (int i = 0; i < 3; i++)
            {
                if (Grille[i, 0] == Grille[i, 1] && Grille[i, 0] == Grille[i, 2] && Grille[i, 0] != 0)
                    numJoueurGagnant = Grille[i, 0] - 1;
            }
            //verif des col
            for (int i = 0; i < 3; i++)
            {
                if (Grille[0, i] == Grille[1, i] && Grille[0, i] == Grille[2, i] && Grille[0, i] != 0)
                    numJoueurGagnant = Grille[0, i] - 1;
            }
            if ((Grille[0, 0] == Grille[1, 1] && Grille[2, 2] == Grille[1, 1])
                || (Grille[0, 2] == Grille[1, 1] && Grille[1, 1] == Grille[2, 0]))
                numJoueurGagnant = Grille[1, 1] - 1;

            if (numJoueurGagnant == -1)
                return null;

            LesJoueurs[numJoueurGagnant].Score++;
            return LesJoueurs[numJoueurGagnant];


        }

        public void ReinitGrille()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Grille[i, j] = 0;
        }
    }


}
