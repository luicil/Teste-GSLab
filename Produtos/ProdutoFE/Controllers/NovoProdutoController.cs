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

        public IActionResult Editar(ProdutoModel produto)
        {
            return View("index", produto);
        }


        public IActionResult Salvar(string nomeproduto, string descrproduto, string vlrproduto, string id)
        {

            if (nomeproduto != null && descrproduto != null && vlrproduto != null)
            {
                var url = Configuration["APIUrl"];
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

                ProdutoModel produto = new ProdutoModel();
                produto.Nome = nomeproduto;
                produto.Descricao = descrproduto;
                produto.Valor = Convert.ToDecimal(vlrproduto);
                if(id != null)
                    produto.Id = Convert.ToInt32(id);

                string errMsg = "";
                HttpResponseMessage httpResponse = null;
                var content = JsonConvert.SerializeObject(produto);

                if(id == null)
                {
                    httpResponse = client.PostAsync("api/Produtos", new StringContent(content, Encoding.Default, "application/json")).Result;
                    errMsg = "Não foi possível incluir o produto";
                }
                else
                {
                    httpResponse = client.PutAsync("api/Produtos/" + id, new StringContent(content, Encoding.Default, "application/json")).Result;
                    errMsg = "Não foi possível alterar o produto";
                }
                if (!httpResponse.IsSuccessStatusCode)
                {
                    ViewBag.error = errMsg;
                    return View();
                }
            }
            else
            {
                ViewBag.error = "Informe todos os dados";
                return View();
            }

            return RedirectToAction("Index", "Home");

        }
    }
}
