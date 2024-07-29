using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSharedMemory2.Service;
using AppSharedMemory2.Model;

namespace AppSharedMemory2
{
    public partial class FrmCategorie : Form
    {
        public FrmCategorie()
        {
            InitializeComponent();
        }
        CategorieService categorieService=new CategorieService();
        private void FrmCategorie_Load(object sender, EventArgs e)
        {
            resetForm();
        }
        public void resetForm()
        {
            dgCategorie.DataSource = categorieService.servGetListCategorie();
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Categorie C = new Categorie();
            C.CodeCategorie = txtCode.Text;
            C.LibelleCode = txtLibelle.Text;
            categorieService.AddCategorie(C);
            resetForm();
            effacer();

        }
        private void effacer()
        {
            txtCode.Text = "";
            txtLibelle.Text = "";
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgCategorie.CurrentRow.Cells[0].Value.ToString());
            Categorie C = new Categorie();
            C.idCategorie = id;
            C.CodeCategorie = txtCode.Text;
            C.LibelleCode = txtLibelle.Text;

            categorieService.UpdateCategorie(C);
            resetForm();
            effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgCategorie.CurrentRow.Cells[0].Value.ToString());
            categorieService.DeleteCategorie(id);
            resetForm();
            effacer();

        }

        private void select(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgCategorie.Rows[e.RowIndex];
            txtCode.Text = row.Cells["CodeCategorie"].Value.ToString();
            txtLibelle.Text = row.Cells["LibelleCode"].Value.ToString();
        }
    }
}
