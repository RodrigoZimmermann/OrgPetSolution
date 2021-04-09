using AutoMapper;
using BLL;
using Domain;
using Domain.Enums;
using MVCLayer.Models;
using MvcPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCLayer.Controllers
{
    public class HomeController : LoggedInBaseController
    {
        private AnimalBLL bll = new AnimalBLL();


        public ActionResult MeusAnimais()
        {
            AnimalBLL bll = new AnimalBLL();
            List<Animal> animais = bll.LerAnimaisUsuariologado(int.Parse(Cookie.Get()));
            return View(animais);
        }

        public ActionResult EncontreiAnimal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EncontreiAnimal(CreateAnimalViewModel viewModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<CreateAnimalViewModel, Animal>());
            var mapper = config.CreateMapper();
            Animal domain = mapper.Map<Animal>(viewModel);
            domain.UsuarioID = int.Parse(Cookie.Get());

            MemoryStream target = new MemoryStream();
            viewModel.ImagemAnimal.InputStream.CopyTo(target);
            domain.Foto = target.ToArray();
            domain.Status = Domain.Enums.Status.Perdido;

            try
            {
                domain.Status = Domain.Enums.Status.Perdido;
                bll.Inserir(domain);
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

        //ajax - assincronamente
        [HttpPost]
        public ActionResult EncontreiAnimalVisionCloud()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    HttpPostedFileBase file = files[0];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }

                    MemoryStream ms = new MemoryStream();
                    file.InputStream.CopyTo(ms);
                    List<string> dados = VisionCloud.VerificarImagem(ms.ToArray());
                    return Json(dados, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Lista()
        {
            AnimalBLL bll = new AnimalBLL();
            List<Animal> ultimos5Cadastrados = bll.Listar();
            return View(ultimos5Cadastrados);
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

        public ActionResult Detalhes(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Lista", "Home");
            }
            Animal animal = bll.LerPorID(id);
            return View(animal);
        }

        public ActionResult RazaoAnimalResgatado(int idAnimal, int razao)
        {
            try
            {
                bll.RegistrarAnimalResgatado(idAnimal, (Status)razao);
                var x = new
                {
                    Sucesso = true,
                    Mensagem = "Status alterado com sucesso!"
                };
                return Json(x, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var x = new
                {
                    Sucesso = false,
                    Mensagem = "Erro no banco de dados."
                };
                return Json(x, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AlterarStatusResgatado(int IdAnimal)
        {
            try
            {
                bll.RegistrarAnimalResgatado(IdAnimal, Domain.Enums.Status.Resgatado);
                var x = new
                {
                    Sucesso = true,
                    Mensagem = "Status alterado com sucesso!"
                };
                return Json(x, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var x = new
                {
                    Sucesso = false,
                    Mensagem = "Erro no banco de dados."
                };
                return Json(x, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CadastroAnimais()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroAnimais(CreateAnimalViewModel viewModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<CreateAnimalViewModel, Animal>());
            var mapper = config.CreateMapper();
            Animal domain = mapper.Map<Animal>(viewModel);
            domain.UsuarioID = int.Parse(Cookie.Get());

            MemoryStream target = new MemoryStream();
            viewModel.ImagemAnimal.InputStream.CopyTo(target);
            domain.Foto = target.ToArray();
            domain.Status = Domain.Enums.Status.Desaparecido;

            try
            {
                bll.Inserir(domain);
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
    }
}