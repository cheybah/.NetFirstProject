using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Categorie
    {
        int codecat;
        string descat;

        public Categorie(int codecat, string descat)
        {
            this.Codecat = codecat;
            this.Descat = descat;
        }

        public int Codecat { get => codecat; set => codecat = value; }
        public string Descat { get => descat; set => descat = value; }
    }
}
