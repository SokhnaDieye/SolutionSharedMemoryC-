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

namespace AppSharedMemory2
{
    public partial class FrmUtilisateur : Form
    {
        WebClient client=new WebClient();
        NameValueCollection dataSend=new NameValueCollection();
        public FrmUtilisateur()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            dataSend["nom"] = txtNom.Text; 
            dataSend["prenom"] = txtPrenom.Text;
            dataSend["age"] = txtAge.Text;

            try
            {
               
                client.UploadValues("http://localhost/backend/create.php", "POST", dataSend);
                resetForm();
                Effacer();
            }
            catch (WebException ex)
            {
                MessageBox.Show("Errer: " + ex.Message);
            }
        }

        private void FrmUtilisateur_Load(object sender, EventArgs e)
        {
            resetForm();
        }
        public void resetForm()
        {
            try
            {
                string response = client.DownloadString("http://localhost/backend/list.php");
                var data = JsonConvert.DeserializeObject<List<Utilisateur>>(response);
                dgUtilisateur.DataSource = data;
            }
            catch (WebException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            dataSend["id"] = txtId.Text;
            dataSend["nom"] = txtNom.Text;
            dataSend["prenom"] = txtPrenom.Text;
            dataSend["age"] = txtAge.Text;

            try
            {
                client.UploadValues("http://localhost/backend/Update.php", "POST", dataSend);
                resetForm();
                Effacer();
            }
            catch (WebException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            dataSend["id"] = txtId.Text;

            try
            {
                
               client.UploadValues("http://localhost/backend/Delete.php", "POST", dataSend);
               resetForm();
                Effacer();
            }
            catch (WebException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

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
    }
}
