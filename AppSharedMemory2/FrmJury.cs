using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace AppSharedMemory2
{
    public partial class FrmJury : Form
    {
        ServiceMetier.Service1Client service;
        public FrmJury()
        {
            service = new ServiceMetier.Service1Client();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                resetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des données : {ex.Message}");
            }

        }

        /// <summary>
        /// Fonction qui permet de reactualiser le DataGridView
        /// </summary>
        private void resetForm()
        {
            dgJury.DataSource = service.GetJury();
        }
        /// <summary>
        /// Effacer le formulaire
        /// </summary>
        public void Effacer()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtGrade.Text = string.Empty;
            txtSpecialite.Text = string.Empty;
            dgJury.DataSource = service.GetJury();
            txtNom.Focus();
        }
        /// <summary>
        /// Ajout jury
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ServiceMetier.jury jury = new ServiceMetier.jury();
            jury.Nom = txtNom.Text;
            jury.Prenom = txtPrenom.Text;
            jury.Grade = txtGrade.Text;
            jury.Specialite = txtSpecialite.Text;
            service.AddJury(jury);
            Effacer();
            resetForm();
        }
        /// <summary>
        /// Modifier jury
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            int juryId = int.Parse(dgJury.CurrentRow.Cells[2].Value.ToString());
            ServiceMetier.jury jury = new ServiceMetier.jury
            {
                IdPersonne = juryId,
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                Specialite = txtSpecialite.Text,
                Grade = txtGrade.Text
            };
            service.EditJury(jury);
            Effacer();
            resetForm();
        }
        /// <summary>
        /// Supprimer un jury
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {

            int juryId = int.Parse(dgJury.CurrentRow.Cells[2].Value.ToString());
            service.DeleteJury(juryId);
            resetForm();
            Effacer();

        }
        /// <summary>
        /// Permet de remplir le formulaire a partir du DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgJury_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgJury.Rows[e.RowIndex];
            txtNom.Text = row.Cells["Nom"].Value.ToString();
            txtPrenom.Text = row.Cells["Prenom"].Value.ToString();
            txtGrade.Text = row.Cells["Grade"].Value.ToString();
            txtSpecialite.Text = row.Cells["Specialite"].Value.ToString();
        }
    }
}
