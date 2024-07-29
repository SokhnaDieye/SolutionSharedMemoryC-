using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppSharedMemory2.Model;

namespace AppSharedMemory2.Service
{
    public class CategorieService
    {

        public List<Categorie> servGetListCategorie()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Categorie>();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["linkServeur"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("sokhna/Categories/GetCategorie").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Categorie>>(responseData);
            }
            return services;
        }

        public bool AddCategorie(Categorie emp)
        {
            bool rep = false;
            string Id = emp.idCategorie> 0 ? emp.idCategorie.ToString() : "0";
            var values = new Dictionary<string, string>
                    {
                       { "idCategorie", Id },
                       { "CodeCategorie", emp.CodeCategorie.ToString() },
                       { "LibelleCode", emp.LibelleCode }
                    };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["linkServeur"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PostAsync("sokhna/Categories/PostCategorie", content).Result;
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

        public bool UpdateCategorie(Categorie emp)
        {
            bool rep = false;
            var values = new Dictionary<string, string>
            {
                { "idCategorie", emp.idCategorie.ToString() },
                { "CodeCategorie", emp.CodeCategorie },
                { "LibelleCode", emp.LibelleCode }
            };
            var content = new FormUrlEncodedContent(values);

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["linkServeur"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PutAsync($"sokhna/Categories/PutCategorie/{emp.idCategorie}", content).Result;
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

        public bool DeleteCategorie(int id)
        {
            bool rep = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["linkServeur"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.DeleteAsync($"sokhna/Categories/DeleteCategorie/{id}").Result;
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

    }
}
