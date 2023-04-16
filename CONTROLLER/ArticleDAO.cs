using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODEL;
using Microsoft.VisualBasic;

namespace CONTROLLER
{
    public class ArticleDAO
    {
        public static ArticleDAO obje;
        public List<Article> liste = new List<Article>();
        public bool isloaded = false;


        public static ArticleDAO getInstance()
        {
            if (obje == null)
            {
                obje = new ArticleDAO();
            }
            return obje;
        }
        public void load_article()
        {
            if (!(this.isloaded))
            {
                Connexion.connecter();
                System.Data.SqlClient.SqlDataReader reader = Connexion.Rdd("select * from Article");

                int codeart;
                String desart;
                float pu;
                Categorie codecat;
                while (reader.Read())
                {
                    codeart = (int)reader.GetValue(0);
                    desart = (String)reader.GetValue(1);
                    pu = (float)reader.GetValue(2);
                    codecat = (Categorie)reader.GetValue(3);



                    Article article = new Article(codeart, desart, pu, codecat);
                    liste.Add(article);
                }
                reader.Close();
                Connexion.conn.Close();
                this.isloaded = true;
            }
        }

        public void save_article(Article clie)
        {
            Connexion.connecter();
            SqlCommand requete = new SqlCommand();
            requete.Connection = Connexion.conn;

            SqlParameter p_codeart = new SqlParameter("@codeart", SqlDbType.Int);
            SqlParameter p_desart = new SqlParameter("@desart", SqlDbType.VarChar);
            SqlParameter p_pu = new SqlParameter("@pu", SqlDbType.Float);
            SqlParameter p_codecat = new SqlParameter("@codecat", .Categorie);
            requete.CommandText = "insert into Client(code_cli,nom,prenom,addr,tel,email) values(@code_cli,@nom,@prenom,@addr,@tel,@email)";
            requete.CommandType = CommandType.Text;


            p_codeart.Value = clie.Codeart;
            p_desart.Value = clie.Desart;
            p_pu.Value = clie.Pu;
            p_codecat.Value = clie.Codecat;

            requete.Parameters.Add(p_codeart);
            requete.Parameters.Add(p_desart);
            requete.Parameters.Add(p_pu);
            requete.Parameters.Add(p_codecat);
            // requete.CommandText = "insert into Client(id_clt,num_clt,nom_clt,adr_clt,tel_clt,email_clt,post_clt,cin_clt) values(1,@num_clt,1232,DSFCSDFC,234234,RZER,2344,4324234)"

            requete.ExecuteReader(); //alt
            //Connexion.executeCommand(requete);
            //Interaction.MsgBox("Client ajouté avec succés");
        }

        public void delete_article(Article article)
        {
            Connexion.connecter();
            // requete pour supprimer un client
            System.Data.SqlClient.SqlCommand requete = new System.Data.SqlClient.SqlCommand("delete from Client where client.Codecli ='" + clien.Codecli + "'");
            requete.CommandType = System.Data.CommandType.Text;
            requete.ExecuteReader();
            //Connexion.executeCommand(requete);
            //Interaction.MsgBox("Supression du Client est effectué avec succés");
        }

        public void update_client(Client client)
        {
            Connexion.connecter();
            System.Data.SqlClient.SqlCommand requete = new System.Data.SqlClient.SqlCommand("update client set nom = '" + client.Nom + "',prenom = '" + client.Prenom + "',addr = " + client.Addr + ",tel = " + client.Tel + ",email = " + client.Email + ",email_clt = '" + client.Email + "' where id_clt = " + client.Codecli + "");
            requete.CommandType = System.Data.CommandType.Text;
            requete.ExecuteReader();
            //Connexion.executeCommand(requete);
            //Interaction.MsgBox("MAJ effetué avec succés");
        }

        public Client Getclient_ById(int var)
        {
            if (liste.Count == 0)
                this.load_client();
            foreach (Client Item in liste)

            {
                if (Item.Codecli.Equals(var))
                    return Item;
            }
            return null;
        }
    }
}
