using Clase_Practica.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Practica.Services
{
    public class LoginService
    {
        public async Task<bool> LoginAsync(string user, string password)
        {
            var requestUri = new Uri("http://181.113.32.53/sis/CenturiosWS/login.php");
            var client = new HttpClient();

            var login = new Login
            {
                User = user,
                Clave = password
            };

            var json = JsonConvert.SerializeObject(login);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUri, contentJson);

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
