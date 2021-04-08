using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public virtual ICollection<Animal> Animais { get; set; }
    }
}
