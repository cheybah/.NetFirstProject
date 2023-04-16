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
    public class ClientDAO
    {
        public static ClientDAO obje;
        public List<Client> liste = new List<Client>();
        public bool isloaded = false;


        public static ClientDAO getInstance()
        {
            if (obje == null)
            {
                obje = new ClientDAO();
            }
            return obje;
        }
        public void load_client()
        {
            if (!(this.isloaded))
            {
                Connexion.connecter();
                System.Data.SqlClient.SqlDataReader reader = Connexion.Rdd("select * from Client");

                int codecli;
                String nom;
                String prenom;
                String addr;
                String tel;
                String email;
                while (reader.Read())
                {
                    codecli = (int)reader.GetValue(0);
                    nom = (String)reader.GetValue(1);
                    prenom = (String)reader.GetValue(2);
                    addr = (String)reader.GetValue(3);
                    tel = (String)reader.GetValue(4);
                    email = (String)reader.GetValue(5);


                    Client client = new Client(codecli, nom, prenom, addr, tel, email);
                    liste.Add(client);
                }
                reader.Close();
                Connexion.conn.Close();
                this.isloaded = true;
            }
        }

        public void save_client(Client clie)
        {
            Connexion.connecter();
            SqlCommand requete = new SqlCommand();
            requete.Connection = Connexion.conn;

            SqlParameter p_code_cli = new SqlParameter("@code_cli", SqlDbType.Int);
            SqlParameter p_nom = new SqlParameter("@nom", SqlDbType.VarChar);
            SqlParameter p_prenom = new SqlParameter("@prenom", SqlDbType.VarChar);
            SqlParameter p_addr = new SqlParameter("@addr", SqlDbType.VarChar);
            SqlParameter p_tel = new SqlParameter("@tel", SqlDbType.VarChar);
            SqlParameter p_email = new SqlParameter("@email", SqlDbType.VarChar);
            requete.CommandText = "insert into Client(code_cli,nom,prenom,addr,tel,email) values(@code_cli,@nom,@prenom,@addr,@tel,@email)";
            requete.CommandType = CommandType.Text;


            p_code_cli.Value = clie.Codecli;
            p_nom.Value = clie.Nom;
            p_prenom.Value = clie.Prenom;
            p_addr.Value = clie.Addr;
            p_tel.Value = clie.Tel;
            p_email.Value = clie.Email;

            requete.Parameters.Add(p_code_cli);
            requete.Parameters.Add(p_nom);
            requete.Parameters.Add(p_prenom);
            requete.Parameters.Add(p_addr);
            requete.Parameters.Add(p_tel);
            requete.Parameters.Add(p_email);
            // requete.CommandText = "insert into Client(id_clt,num_clt,nom_clt,adr_clt,tel_clt,email_clt,post_clt,cin_clt) values(1,@num_clt,1232,DSFCSDFC,234234,RZER,2344,4324234)"

            requete.ExecuteReader(); //alt
            //Connexion.executeCommand(requete);
            //Interaction.MsgBox("Client ajouté avec succés");
        }

        public void delete_client(Client clien)
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
