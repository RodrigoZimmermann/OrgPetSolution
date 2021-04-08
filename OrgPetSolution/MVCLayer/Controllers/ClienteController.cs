using AutoMapper;
using BLL;
using Domain;
using MVCLayer.Models;
using MvcPresentationLayer.Models;
using System.Text;
using System.Web.Mvc;

namespace MVCLayer.Controllers
{
    public class ClienteController : Controller
    {
        UsuarioBLL bll = new UsuarioBLL();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CriarLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarLogin(CreateUsuarioViewModel usuario)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<CreateUsuarioViewModel, Usuario>());
            var mapper = config.CreateMapper();
            Usuario domain = mapper.Map<Usuario>(usuario);
            try
            {
                bll.Inserir(domain);
                Cookie.Set(domain.ID.ToString());
                return RedirectToAction("Lista", "Home");
            }
            catch (PetShopException ex)
            {
                StringBuilder errors = new StringBuilder();
                foreach (ErrorField item in ex.Errors)
                {
                    errors.Append("<div style='display: block'>" + item.Error + "</div>");
                }
                ViewBag.Erros = errors.ToString();
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string senha)
        {
            Usuario usuario = bll.Autenticar(email, senha);
            if (usuario != null)
            {
                Cookie.Set(usuario.ID.ToString());
            }
            ViewBag.Erro = "Email e/ou senha incorretos.";
            return View();
        }

        public ActionResult RecuperarLogin()
        {
            return View();
        }
    }
}