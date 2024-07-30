using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Net.Http.Headers;
using AppSharedMemory2.Model;
using ApiMtier.Controllers;

namespace AppSharedMemory2.Service
{
    public class UtilisateurServices
    {
        /// <summary>
        /// Lister les utilisateur
        /// </summary>
        /// <returns></returns>
        public List<Utilisateur> servGetListUtilisateur()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Utilisateur>();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LinkServeurPhp"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("list.php").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Utilisateur>>(responseData);
            }
            return services;
        }
        /// <summary>
        /// Ajout utilisateur
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>

        public bool AddUtilisateur(Utilisateur emp)
        {
            bool rep = false;
            string Id = emp.Id > 0 ? emp.Id.ToString() : "0";
            var values = new Dictionary<string, string>
                    {
                       { "id", Id },
                       { "nom", emp.Nom.ToString() },
                       { "prenom", emp.Prenom.ToString() },
                       { "age", emp.Age.ToString() }
                    };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LinkServeurPhp"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PostAsync("create.php", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public bool UpdateUtilisateur(Utilisateur emp)
        {
            bool rep = false;
            var values = new Dictionary<string, string>
            {
                       { "id", emp.Id.ToString() },
                       { "nom", emp.Nom },
                       { "prenom", emp.Prenom },
                       { "age", emp.Age.ToString() }
                    };
            var content = new FormUrlEncodedContent(values);

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LinkServeurPhp"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PostAsync($"Update.php/{emp.Id}", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return rep;
        }

        public bool DeleteUtilisateur(Utilisateur emp)
        {
            bool rep = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LinkServeurPhp"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var values = new Dictionary<string, string>
            {
                { "id", emp.Id.ToString() }
            };
                    var content = new FormUrlEncodedContent(values);

                    var response = client.PostAsync("Delete.php", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        var errorMessage = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine("Error: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return rep;
        }



    }
}
