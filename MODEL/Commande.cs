using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Commande
    {
        int codecmd;
        string datecmd;
        string addrs;
        Client codeclient;

        public Commande(int codecmd, string datecmd, string addrs, Client codeclient)
        {
            this.Codecmd = codecmd;
            this.Datecmd = datecmd;
            this.Addrs = addrs;
            this.Codeclient = codeclient;
        }

        public int Codecmd { get => codecmd; set => codecmd = value; }
        public string Datecmd { get => datecmd; set => datecmd = value; }
        public string Addrs { get => addrs; set => addrs = value; }
        public Client Codeclient { get => codeclient; set => codeclient = value; }
    }
}
