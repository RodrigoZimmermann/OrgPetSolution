using Domain;
using MVCLayer.Models;
using MvcPresentationLayer.Models;
using System.Web.Mvc;

namespace MVCLayer.Controllers
{
    public class HomeController : LoggedInBaseController
    {
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Lista()
        {
            return View();
        }

        public ActionResult AnimaisDesaparecidos()
        {
            return View();
        }

        public ActionResult RecuperarLogin()
        {
            return View();
        }

        public ActionResult AnimaisEncontrados()
        {
            return View();
        }

        public ActionResult AnimaisParaAdoção()
        {
            return View();
        }

        public ActionResult MapaDePetShop()
        {
            return View();
        }

        public ActionResult CadastroAnimais()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroAnimais(CreateAnimalViewModel viewModel)
        {
            Animal animal = new Animal();
            animal.UsuarioID = int.Parse(Cookie.Get());
            return View();
        }
    }
}