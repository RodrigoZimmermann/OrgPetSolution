using BLL.Extensions;
using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL : IUsuarioService
    {
        private bool VerificarSenhaValida(string senha)
        {
            int countNumbers = 1;
            int countLetters = 5;
            int countUpper = 1;

            foreach (char caracter in senha)
            {
                if (char.IsNumber(caracter))
                {
                    countNumbers++;
                }
                else if (char.IsLetter(caracter))
                {
                    countLetters++;
                    if (char.IsUpper(caracter))
                    {
                        countUpper++;
                    }
                }
            }
            return true;
        }

        List<ErrorField> erros = new List<ErrorField>();
        public void Inserir(Usuario usuario)
        {
            #region CPF
            if (string.IsNullOrWhiteSpace(usuario.CPF))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "CPF deve ser informado.",
                    PropertyName = "CPF"
                };
                erros.Add(error);
            }
            else
            {
                usuario.CPF = usuario.CPF.Trim();
                usuario.CPF = usuario.CPF.Replace(".", "").Replace("-", "").Replace(",", "");
                if (!usuario.CPF.IsValidCPF())
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "CPF inválido.",
                        PropertyName = "CPF"
                    };
                    erros.Add(error);
                }
            }
            #endregion

            #region Nome
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome deve ser informado.",
                    PropertyName = "Nome"
                };
                erros.Add(error);
            }
            else
            {
                usuario.Nome = usuario.Nome.Trim();
                if (usuario.Nome.Length < 3 || usuario.Nome.Length > 70)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Nome deve conter entre 3 e 70 caracteres.",
                        PropertyName = "Nome"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < usuario.Nome.Length; i++)
                    {
                        if (!char.IsLetter(usuario.Nome[i]) && usuario.Nome[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Nome Inválido ou com muitos espaços. (OBS. Utilizar apenas um espaço por nome)",
                                PropertyName = "Nome"
                            };
                            erros.Add(error);
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Email
            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email deve ser informado.",
                    PropertyName = "Email"
                };
                erros.Add(error);
            }
            else if (!Regex.IsMatch(usuario.Email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email inválido.",
                    PropertyName = "Email"
                };
                erros.Add(error);
            }

            #endregion

            #region Senha
            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Senha deve ser informado.",
                    PropertyName = "Senha"
                };
                erros.Add(error);
            }
            else
            {
                usuario.Senha = usuario.Senha.Trim();
                if (usuario.Senha.Length < 5 || usuario.Senha.Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Senha deve conter entre 5 e 15 caracteres.",
                        PropertyName = "Senha"
                    };
                    erros.Add(error);
                }
                else if (!VerificarSenhaValida(usuario.Senha))
                {
                    ErrorField error = new ErrorField()
                    {
                        PropertyName = "Senha",
                        Error = "Senha deve conter pelo menos 1 letra maíscula e 1 número."
                    };
                    erros.Add(error);
                }
            }
            #endregion

            #region celular
            if (string.IsNullOrWhiteSpace(usuario.Celular))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Número de celular deve ser informado.",
                    PropertyName = "Celular"
                };
                erros.Add(error);
            }
            else
            {
                usuario.Celular =
                       usuario.Celular.Replace(" ", "")
                                   .Replace("(", "")
                                   .Replace(")", "")
                                   .Replace("-", "");

                if (usuario.Celular.Length < 9 || usuario.Celular.Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Número do celular deve conter entre 9 e 15 caracteres.",
                        PropertyName = "Celular"
                    };
                    erros.Add(error);
                }
            }
            #endregion

            #region Telefone
            if (string.IsNullOrWhiteSpace(usuario.Telefone))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Número de Telefone deve ser informado.",
                    PropertyName = "Telefone"
                };
                erros.Add(error);
            }
            else
            {
                usuario.Telefone =
                       usuario.Telefone.Replace(" ", "")
                                   .Replace("(", "")
                                   .Replace(")", "")
                                   .Replace("-", "");

                if (usuario.Telefone.Length < 8 || usuario.Telefone.Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Número de Telefone deve conter entre 8 e 15 caracteres.",
                        PropertyName = "Telefone"
                    };
                    erros.Add(error);
                }
            }

            #endregion

            #region CEP 
            if (string.IsNullOrWhiteSpace(usuario.CEP))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "CEP deve ser informado.",
                    PropertyName = "CEP"
                };
                erros.Add(error);
            }
            else
            {
                usuario.CEP = usuario.CEP.Trim();
                usuario.CEP = usuario.CEP.Replace(".", "").Replace("-", "").Replace(",", "");
                if (usuario.CEP.Length != 8)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "CEP deve conter 8 caracteres",
                        PropertyName = "CEP"
                    };
                    erros.Add(error);
                }
            }
            #endregion

            #region Endereço
            if (string.IsNullOrWhiteSpace(usuario.Endereco))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Endereço deve ser informado.",
                    PropertyName = "Endereco"
                };
                erros.Add(error);
            }
            else
            {
                if (usuario.Endereco.Length > 100)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "limite de caracteres do endereço ultrapassado.",
                        PropertyName = "Endereco"
                    };
                    erros.Add(error);
                }
            }
            #endregion

            if (erros.Count != 0)
            {
                throw new PetShopException(erros);
            }


            using (PetContext pet = new PetContext())
            {
                pet.Usuario.Add(usuario);
                pet.SaveChanges();
            }
        }

        public void Atualizar(Usuario usuario)
        {
            #region Nome
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome deve ser informado.",
                    PropertyName = "Nome"
                };
                erros.Add(error);
            }
            else if (usuario.Nome.Length < 3 || usuario.Nome.Length > 70)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome deve conter entre 3 e 70 caracteres.",
                    PropertyName = "Nome"
                };
                erros.Add(error);
            }
            #endregion

            #region Email
            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email deve ser informado.",
                    PropertyName = "Email"
                };
                erros.Add(error);
            }
            else if (!Regex.IsMatch(usuario.Email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email inválido.",
                    PropertyName = "Email"
                };
                erros.Add(error);
            }
            #endregion

            #region Senha
            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Senha deve ser informado.",
                    PropertyName = "Senha"
                };
                erros.Add(error);
            }
            else
            {
                usuario.Senha = usuario.Senha.Trim();
                if (usuario.Senha.Length < 5 || usuario.Senha.Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Senha deve conter entre 5 e 15 caracteres.",
                        PropertyName = "Senha"
                    };
                    erros.Add(error);
                }
                else if (!VerificarSenhaValida(usuario.Senha))
                {
                    ErrorField error = new ErrorField()
                    {
                        PropertyName = "Senha",
                        Error = "Senha deve conter pelo menos 1 letra maíscula, 1 letra minúscula, 1 símbolo e 1 número."
                    };
                    erros.Add(error);
                }
            }
            #endregion

            #region Celular
            if (string.IsNullOrWhiteSpace(usuario.Celular))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Telefone deve ser informado.",
                    PropertyName = "Telefone"
                };
                erros.Add(error);
            }
            else if (usuario.Celular.Length < 9 || usuario.Celular.Length > 15)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Número de celular deve conter entre 9 e 15 caracteres.",
                    PropertyName = "Telefone"
                };
                erros.Add(error);
            }
            #endregion

            #region Telefone
            if (string.IsNullOrWhiteSpace(usuario.Telefone))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Número de Telefone deve ser informado.",
                    PropertyName = "Telefone"
                };
                erros.Add(error);
            }
            else
            {
                usuario.Telefone =
                       usuario.Telefone.Replace(" ", "")
                                   .Replace("(", "")
                                   .Replace(")", "")
                                   .Replace("-", "");

                if (usuario.Telefone.Length < 8 || usuario.Telefone.Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Número de Telefone deve conter entre 8 e 15 caracteres.",
                        PropertyName = "Telefone"
                    };
                    erros.Add(error);
                }
            }

            #endregion

            #region CEP 
            if (string.IsNullOrWhiteSpace(usuario.CEP))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "CEP deve ser informado.",
                    PropertyName = "CEP"
                };
                erros.Add(error);
            }
            else
            {
                usuario.CEP = usuario.CEP.Trim();
                usuario.CEP = usuario.CEP.Replace(".", "").Replace("-", "").Replace(",", "");
                if (usuario.CEP.Length != 8)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "CEP deve conter 8 caracteres",
                        PropertyName = "CEP"
                    };
                    erros.Add(error);
                }
            }
            #endregion

            #region Endereço
            if (string.IsNullOrWhiteSpace(usuario.Endereco))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Endereço deve ser informado.",
                    PropertyName = "Endereco"
                };
                erros.Add(error);
            }
            else
            {
                if (usuario.Endereco.Length > 100)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "limite de caracteres do endereço ultrapassado.",
                        PropertyName = "Endereco"
                    };
                    erros.Add(error);
                }
            }
            #endregion

            if (erros.Count != 0)
            {
                throw new PetShopException(erros);
            }

            using (PetContext pet = new PetContext())
            {
                pet.Entry<Usuario>(usuario).State = System.Data.Entity.EntityState.Modified;
                pet.SaveChanges();
            }
        }
        public void Excluir(Usuario usuario)
        {
            if (usuario.ID <= 0)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Endereço de ID inválido",
                    PropertyName = "ID"
                };
                erros.Add(error);
            }

            if (erros.Count != 0)
            {
                throw new PetShopException(erros);
            }

            using (PetContext pet = new PetContext())
            {
                pet.Entry<Usuario>(usuario).State = System.Data.Entity.EntityState.Deleted;
                pet.SaveChanges();
            }
        }
        public Usuario Autenticar(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ErrorField error = new ErrorField()
                {
                    PropertyName = "Email",
                    Error = "Nome de usuário deve ser informado"
                };
                erros.Add(error);
            }
            if (string.IsNullOrWhiteSpace(senha))
            {
                ErrorField error = new ErrorField()
                {
                    PropertyName = "Senha",
                    Error = "Senha deve ser informada."
                };
                erros.Add(error);
            }
            else if (senha.Length < 5 || senha.Length > 15)
            {
                ErrorField error = new ErrorField()
                {
                    PropertyName = "Senha",
                    Error = "Senha deve conter entre 5 e 15 caracteres."
                };
                erros.Add(error);
            }
            else if (!VerificarSenhaValida(senha))
            {
                ErrorField error = new ErrorField()
                {
                    PropertyName = "Senha",
                    Error = "Senha deve conter pelo menos 1 letra maiúscula e 1 número."
                };
                erros.Add(error);
            }

            if (erros.Count != 0)
            {
                throw new PetShopException(erros);
            }
            //string senhaHasheada = HashUtils.HashPassword(senha);
            using (PetContext ctx = new PetContext())
            {
                //select * from usuarios where username = 'ronaldo' and passoword = '09ur98ucvsf89f'
                Usuario user =
                    ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
                return user;
            }
        }


        public List<Animal> LerAnimaisUsuario(int id)
        {
            using (PetContext db = new PetContext())
            {
                return db.Usuario.Find(id).Animais.ToList();
            }
        }

        public Usuario LerPorID(int id)
        {
            using (PetContext db = new PetContext())
            {
                return db.Usuario.Find(id);
            }
        }

        public List<Usuario> Listar()
        {
            using (PetContext pet = new PetContext())
            {
                return pet.Usuario.ToList();
            }
        }
    }
}
