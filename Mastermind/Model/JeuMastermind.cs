using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Model
{
    public class Jeu
    {

        private int nbEssais;
        private int nbEssaisPossibles;

        public int NbEssaisPossibles
        {
            get { return nbEssaisPossibles; }
            set { nbEssaisPossibles = value; }
        }

        private int nbCouleurs;

        public int NbCouleurs
        {
            get { return nbCouleurs; }
            set { nbCouleurs = value; }
        }

        private int nbBilles;

        public int NbBilles
        {
            get { return nbBilles; }
            set { nbBilles = value; }
        }

        private int[] combinaison;

        public int[] Combinaison
        {
            get { return combinaison; }
            set { combinaison = value; }
        }

        private int nbMP;

        public int NbMP
        {
            get { return nbMP; }
            set { nbMP = value; }
        }

        private int nbBP;

        public int NbBP
        {
            get { return nbBP; }
            set { nbBP = value; }
        }

        public Jeu():this(6,10,4)
        {
            Initialise();  
        }

        public Jeu(int nbCouleurs, int nbEssaisPossibles, int nbBilles)
        {
            
            NbCouleurs = nbCouleurs;
            NbEssaisPossibles = nbEssaisPossibles;
            NbBilles = nbBilles;
            Initialise();

        }

        public void Initialise()
        {
            nbEssais = 0;
            NbMP = 0;
            NbBP = 0;
            Combinaison = new int[nbBilles];
            Random r = new Random();

            for (int i = 0; i < nbBilles; i++)
            { Combinaison[i] = (r.Next(nbCouleurs)) + 1; }

        }


        public bool Analyse(int[] proposition)
        {
            nbBP = 0;
            nbMP = 0;
            int[] jeu = new int[NbBilles];
            int[] combiJeu = new int[NbBilles];
            int j, k;
            for (j = 0; j < nbBilles; j++)
            {
                jeu[j] = Combinaison[j];
                if (jeu[j] == proposition[j])
                {
                    nbBP++;
                    jeu[j] = -1; // bien placé
                    proposition[j] = -2; //bien placé
                }
            }

            for (j = 0; j < NbBilles; j++)
            {
                for (k = 0; k < NbBilles; k++)
                    if (j != k && jeu[j] == proposition[k])
                    {
                        nbMP++;
                        jeu[j] = -3; // mal placé
                        proposition[k] = -4; // mal placé
                    }
            }

            nbEssais++;
            if (NbBP == NbBilles)
                Termine();

            return (NbBP == NbBilles);
        }


        public bool EncoreEssai()
        { return NbEssaisPossibles > nbEssais; }

        public void Termine()
        { this.nbEssais = NbEssaisPossibles; }


    }
}
