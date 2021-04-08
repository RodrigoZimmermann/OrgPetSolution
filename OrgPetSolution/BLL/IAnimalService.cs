using Domain;
using System.Collections.Generic;

namespace BLL
{
    public interface IAnimalService
    {
        void Inserir(Animal animal);
        void Atualizar(Animal animal);
        void Excluir(Animal animal);
        List<Animal> Listar();
        Animal LerPorID(int id);
    }
}
