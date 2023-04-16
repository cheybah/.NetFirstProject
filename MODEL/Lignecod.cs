using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Lignecod
    {
        int codeligne;
        int qtecode;
        int codeArticle;
        int codeCommande;

        public Lignecod(int codeligne, int qtecode, int codeArticle, int codeCommande)
        {
            this.Codeligne = codeligne;
            this.Qtecode = qtecode;
            this.CodeArticle = codeArticle;
            this.CodeCommande = codeCommande;
        }

        public int Codeligne { get => codeligne; set => codeligne = value; }
        public int Qtecode { get => qtecode; set => qtecode = value; }
        public int CodeArticle { get => codeArticle; set => codeArticle = value; }
        public int CodeCommande { get => codeCommande; set => codeCommande = value; }
    }

}
