using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUsuarioService
    {
        void Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Excluir(Usuario usuario);
        Usuario Autenticar(string email, string senha);
        List<Usuario> Listar();
        Usuario LerPorID(int id);
        List<Animal> LerAnimaisUsuario(int id);
    }
}
