using System;

namespace MODEL
{
    public class Article
    {
        int codeart;
        string desart;
        float pu;
        Categorie codecat;

        public Article(int codeart, string desart, float pu, Categorie codecat)
        {
            this.Codeart = codeart;
            this.Desart = desart;
            this.Pu = pu;
            this.Codecat = codecat;
        }

        public int Codeart { get => codeart; set => codeart = value; }
        public string Desart { get => desart; set => desart = value; }
        public float Pu { get => pu; set => pu = value; }
        public Categorie Codecat { get => codecat; set => codecat = value; }
    }
}
