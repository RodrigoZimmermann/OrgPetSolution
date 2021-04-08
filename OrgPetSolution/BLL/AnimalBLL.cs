using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Domain;

namespace BLL
{
    public class AnimalBLL : IAnimalService
    {
        List<ErrorField> erros = new List<ErrorField>();
        public void Inserir(Animal animal)
        {
            #region Nome
            if (string.IsNullOrWhiteSpace(animal.Nome))
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
                animal.Nome = animal.Nome.Trim();
                if (animal.Nome.Length < 3 || animal.Nome.Length > 30)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Nome deve conter entre 3 e 30 caracteres.",
                        PropertyName = "Nome"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Nome.Length; i++)
                    {
                        if (!char.IsLetter(animal.Nome[i]) && animal.Nome[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Nome Inválido ou com muitos espaços. (OBS. Utilizar apenas um espaço por nome)",
                                PropertyName = "Nome"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Raça
            if (string.IsNullOrWhiteSpace(animal.Raça))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome da Raça deve ser informado.",
                    PropertyName = "Raca"
                };
                erros.Add(error);
            }
            else
            {
                animal.Raça = animal.Raça.Trim();
                if (animal.Raça.Length < 3 || animal.Raça.Length > 20)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Nome da Raça deve conter entre 3 e 20 caracteres.",
                        PropertyName = "Raca"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Raça.Length; i++)
                    {
                        if (!char.IsLetter(animal.Raça[i]) && animal.Raça[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Nome de Raça inválido ou com muitos espaços. (OBS. Utilizar apenas um espaço por nome)",
                                PropertyName = "Raca"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Tipo
            if (string.IsNullOrWhiteSpace(animal.Tipo.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe se o seu animal é um cachorro ou um gato.",
                    PropertyName = "Tipo"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.Tipo.ToString().Length < 3 || animal.Tipo.ToString().Length > 20)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Tipo de animal com número de caracteres excedido.",
                        PropertyName = "Tipo"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Tipo.ToString().Length; i++)
                    {
                        if (!char.IsLetter(animal.Tipo.ToString()[i]) && animal.Tipo.ToString()[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Tipo inválido ou número de espassos excedido.",
                                PropertyName = "Tipo"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Gênero
            if (string.IsNullOrWhiteSpace(animal.Genero.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Gênero do animal deve ser informado.",
                    PropertyName = "Genero"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.Genero.ToString().Length < 3 || animal.Genero.ToString().Length > 10)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Gênero com número de caracteres excedido.",
                        PropertyName = "Genero"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Genero.ToString().Length; i++)
                    {
                        if (!char.IsLetter(animal.Genero.ToString()[i]) && animal.Genero.ToString()[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Gênero inválido ou número de espassos excedido.",
                                PropertyName = "Genero"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region EhCastrado
            if (string.IsNullOrWhiteSpace(animal.EhCastrado.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe se o seu animal é castrado ou não.",
                    PropertyName = "EhCastrado"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.EhCastrado.ToString().Length < 4 && animal.EhCastrado.ToString().Length > 5)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Informação sobre castração com número de caracteres excedido.",
                        PropertyName = "EhCastrado"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.EhCastrado.ToString().Length; i++)
                    {
                        if (!char.IsLetter(animal.EhCastrado.ToString()[i]) && animal.EhCastrado.ToString()[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Gênero inválido ou número de espassos excedido.",
                                PropertyName = "Genero"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Cor
            if (string.IsNullOrWhiteSpace(animal.Cor.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe a cor do seu animal.",
                    PropertyName = "Cor"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.Cor.ToString().Length < 3 || animal.Cor.ToString().Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Cor com número de caracteres excedido.",
                        PropertyName = "Cor"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Cor.ToString().Length; i++)
                    {
                        if (!char.IsLetter(animal.Cor.ToString()[i]) && animal.Cor.ToString()[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Cor inválida ou número de espassos excedido.",
                                PropertyName = "Cor"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Porte
            if (string.IsNullOrWhiteSpace(animal.Porte.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe o Porte do seu animal.",
                    PropertyName = "Porte"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.Porte.ToString().Length < 3 || animal.Porte.ToString().Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Porte com número de caracteres excedido.",
                        PropertyName = "Porte"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Porte.ToString().Length; i++)
                    {
                        if (!char.IsLetter(animal.Porte.ToString()[i]) && animal.Porte.ToString()[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Porte inválido ou número de espassos excedido.",
                                PropertyName = "Porte"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Observação
            if (string.IsNullOrWhiteSpace(animal.Observacao))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe uma observação sobre seu animal para que seja mais facil encontrá-lo.",
                    PropertyName = "Observacao"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.Observacao.ToString().Length < 10 || animal.Observacao.ToString().Length > 255)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Observação com número de caracteres excedido.",
                        PropertyName = "Observacao"
                    };
                    erros.Add(error);
                }
            }
            #endregion

            #region UsuarioID
            if (string.IsNullOrWhiteSpace(animal.UsuarioID.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe o ID do Dono do animal.",
                    PropertyName = "UsuarioID"
                };
                erros.Add(error);
            }
            #endregion


            if (erros.Count != 0)
            {
                throw new PetShopException(erros);
            }

            using (PetContext pet = new PetContext())
            {
                pet.Animais.Add(animal);
                pet.SaveChanges();
            }
        }

        public void Atualizar(Animal animal)
        {
            #region Nome
            if (string.IsNullOrWhiteSpace(animal.Nome))
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
                animal.Nome = animal.Nome.Trim();
                if (animal.Nome.Length < 3 || animal.Nome.Length > 30)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Nome deve conter entre 3 e 30 caracteres.",
                        PropertyName = "Nome"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Nome.Length; i++)
                    {
                        if (!char.IsLetter(animal.Nome[i]) && animal.Nome[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Nome Inválido ou com muitos espaços. (OBS. Utilizar apenas um espaço por nome)",
                                PropertyName = "Nome"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region EhCastrado
            if (string.IsNullOrWhiteSpace(animal.EhCastrado.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe se o seu animal é castrado ou não.",
                    PropertyName = "EhCastrado"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.EhCastrado.ToString().Length < 4 && animal.EhCastrado.ToString().Length > 5)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Informação sobre castração com número de caracteres excedido.",
                        PropertyName = "EhCastrado"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.EhCastrado.ToString().Length; i++)
                    {
                        if (!char.IsLetter(animal.EhCastrado.ToString()[i]) && animal.EhCastrado.ToString()[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Gênero inválido ou número de espassos excedido.",
                                PropertyName = "Genero"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Cor
            if (string.IsNullOrWhiteSpace(animal.Cor.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe a cor do seu animal.",
                    PropertyName = "Cor"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.Cor.ToString().Length < 3 || animal.Cor.ToString().Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Cor com número de caracteres excedido.",
                        PropertyName = "Cor"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Cor.ToString().Length; i++)
                    {
                        if (!char.IsLetter(animal.Cor.ToString()[i]) && animal.Cor.ToString()[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Cor inválida ou número de espassos excedido.",
                                PropertyName = "Cor"
                            };
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Porte
            if (string.IsNullOrWhiteSpace(animal.Porte.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe o Porte do seu animal.",
                    PropertyName = "Porte"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.Porte.ToString().Length < 3 || animal.Porte.ToString().Length > 15)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Porte com número de caracteres excedido.",
                        PropertyName = "Porte"
                    };
                    erros.Add(error);
                }
                else
                {
                    for (int i = 0; i < animal.Porte.ToString().Length; i++)
                    {
                        if (!char.IsLetter(animal.Porte.ToString()[i]) && animal.Porte.ToString()[i] != ' ')
                        {
                            ErrorField error = new ErrorField()
                            {
                                Error = "Porte inválido ou número de espassos excedido.",
                                PropertyName = "Porte"
                            };
                            erros.Add(error);
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Observação
            if (string.IsNullOrWhiteSpace(animal.Observacao))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe uma observação sobre seu animal para que seja mais facil encontrá-lo.",
                    PropertyName = "Observacao"
                };
                erros.Add(error);
            }
            else
            {
                if (animal.Observacao.ToString().Length < 10 || animal.Observacao.ToString().Length > 255)
                {
                    ErrorField error = new ErrorField()
                    {
                        Error = "Observação com número de caracteres excedido.",
                        PropertyName = "Observacao"
                    };
                    erros.Add(error);
                }
            }
            #endregion

            #region UsuarioID
            if (string.IsNullOrWhiteSpace(animal.UsuarioID.ToString()))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Informe o ID do Dono do animal.",
                    PropertyName = "UsuarioID"
                };
                erros.Add(error);
            }
            #endregion

            if (erros.Count != 0)
            {
                throw new PetShopException(erros);
            }

            using (PetContext pet = new PetContext())
            {
                pet.Entry<Animal>(animal).State = System.Data.Entity.EntityState.Modified;
                pet.SaveChanges();
            }
        }

        public void Excluir(Animal animal)
        {
            if (animal.ID <= 0)
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

            //Validar Usuário
            using (PetContext pet = new PetContext())
            {
                pet.Entry<Animal>(animal).State = System.Data.Entity.EntityState.Deleted;
                pet.SaveChanges();
            }
        }

        public Animal LerPorID(int id)
        {
            using (PetContext db = new PetContext())
            {
                return db.Animais.Find(id);
            }
        }

        public List<Animal> Listar()
        {
            using (PetContext pet = new PetContext())
            {
                return pet.Animais.ToList();
            }
        }

    }
}
