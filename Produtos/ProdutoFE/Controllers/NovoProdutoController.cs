using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdutoFE.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProdutoFE.Controllers
{
    public class NovoProdutoController : Controller
    {

        public IConfiguration Configuration { get; }

        public NovoProdutoController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Salvar(string nomeproduto, string descrproduto, string vlrproduto)
        {

            if (nomeproduto != null && descrproduto != null && vlrproduto != null)
            {
                var url = Configuration["APIUrl"];
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));


                ProdutoModel product = new ProdutoModel
                {
                    Nome = nomeproduto,
                    Valor = Convert.ToDecimal(vlrproduto),
                    Descricao = descrproduto
                };


                var content = JsonConvert.SerializeObject(product);
                var httpResponse = client.PostAsync("api/Produtos", new StringContent(content, Encoding.Default, "application/json")).Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    ViewBag.error = "Não foi possível incluir o produto";
                }
            }
            else
            {
                ViewBag.error = "Informe todos os dados";
            }

            RedirectToAction("Index", "Home");

        }
    }
}
