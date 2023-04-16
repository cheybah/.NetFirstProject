using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Client
    {
        int codecli;
        string nom;
        string prenom;
        string addr;
        string tel;
        string email;

        public Client(int codecli, string nom, string prenom, string addr, string tel, string email)
        {
            this.Codecli = codecli;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Addr = addr;
            this.Tel = tel;
            this.Email = email;
        }

        public int Codecli { get => codecli; set => codecli = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Addr { get => addr; set => addr = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Email { get => email; set => email = value; }
    }
}
