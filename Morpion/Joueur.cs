using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class Joueur
    {
        public String Nom { get; set; }
        private int score;

        public int Score
        {
            get { return score; }
            set { if (value >=0) 
                    score = value;
                else throw new ArgumentException("Score positif ou nul");
            }
        }

        public Joueur(String nom)
        {
            Nom = nom;
            Score = 0;
        }
        public override string ToString()
        {
            return "Nom : " + Nom + "\nScore : " + Score;
        }

    }
}
