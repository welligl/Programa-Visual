using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{

    public class HomeController : Controller
    {
        private static IList<Pessoa> PessoaList = new List<Pessoa>
        {
            new Pessoa {Id = 1, Nome = "João"},
            new Pessoa {Id = 2, Nome = "Juao"},
            new Pessoa {Id = 3, Nome = "John"}
        };

        public IList<Pessoa> GetPessoas()
        {

            return PessoaList;
        }
        public Pessoa AddPessoa(string nome)
        {
            try
            {
                var pessoa = new Pessoa { Nome = nome };

                pessoa.Id = PessoaList.Max(p => p.Id) + 1;

                PessoaList.Add(pessoa);

                return pessoa;

            }
            catch { }

            return null;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
