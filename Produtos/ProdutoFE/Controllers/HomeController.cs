using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProdutoFE.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProdutoFE.Controllers
{
    public class HomeController : Controller
    {

        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IActionResult Index()
        {

            HttpClient client = getClient( new HttpClient());
            
            var httpResponse =  client.GetAsync("api/Produtos").Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content =  httpResponse.Content.ReadAsStringAsync().Result;
            List<ProdutoModel> produtos = JsonConvert.DeserializeObject<List<ProdutoModel>>(content);


            return View(produtos);
        }

        public IActionResult Editar(string id)
        {

            HttpClient client = getClient(new HttpClient());
            var httpResponse = client.GetAsync("api/Produtos/" + id).Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            ProdutoModel produto = JsonConvert.DeserializeObject<ProdutoModel>(content);

            return RedirectToAction("Editar", "NovoProduto", produto);
        }

        public IActionResult Excluir(string id)
        {
            HttpClient client = getClient(new HttpClient());
            var httpResponse =  client.DeleteAsync("api/Produtos/" + id).Result;

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private HttpClient getClient(HttpClient client)
        {
            var url = Configuration["APIUrl"];
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            return client;
        }
    }
}
