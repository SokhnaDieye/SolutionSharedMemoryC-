using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AppSharedMemory2.Model;
using ApiMtier.Controllers;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using AppSharedMemory2.Service;

namespace AppSharedMemory2
{
    public partial class FrmUtilisateur : Form
    {
        UtilisateurServices utilisateurService = new UtilisateurServices();
        public FrmUtilisateur()
        {
            InitializeComponent();
        }

        private void FrmUtilisateur_Load(object sender, EventArgs e)
        {
            resetForm();
        }
        public void resetForm()
        {
            dgUtilisateur.DataSource = utilisateurService.servGetListUtilisateur();
        }

        private void Select(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgUtilisateur.Rows[e.RowIndex];
            txtId.Text = row.Cells["id"].Value.ToString();
            txtNom.Text = row.Cells["nom"].Value.ToString();
            txtPrenom.Text = row.Cells["prenom"].Value.ToString();
            txtAge.Text = row.Cells["age"].Value.ToString();
        }
        public void Effacer()
        {
            txtId.Text="";
            txtNom.Text="";
            txtPrenom.Text="";
            txtAge.Text = "";
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Utilisateur u = new Utilisateur();
            u.Nom = txtNom.Text;
            u.Prenom = txtPrenom.Text;
            u.Age = int.Parse(txtAge.Text);
            utilisateurService.AddUtilisateur(u);
            resetForm();
            Effacer();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
            Utilisateur u = new Utilisateur();
            u.Id = id;
            u.Nom = txtNom.Text;
            u.Prenom = txtPrenom.Text;
            u.Age = int.Parse(txtAge.Text);
            utilisateurService.UpdateUtilisateur(u);
            resetForm();
            Effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
            Utilisateur u = new Utilisateur { Id = id };

            bool result = utilisateurService.DeleteUtilisateur(u);
            if (result)
            {
                Console.WriteLine($"identifiant:  {u.Id}");
                MessageBox.Show("Utilisateur supprimé avec succès ");
                resetForm();
                Effacer();
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression de l'utilisateur");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtNom.Text = dgUtilisateur.CurrentRow.Cells[1].Value.ToString();
            txtPrenom.Text = dgUtilisateur.CurrentRow.Cells[2].Value.ToString();
            txtAge.Text= dgUtilisateur.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
