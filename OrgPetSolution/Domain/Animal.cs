using Domain.Enums;
using System.Collections.Generic;

namespace Domain
{
    public class Animal
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Raça { get; set; }
        public byte[] Foto { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public Genero Genero { get; set; }
        public bool EhCastrado { get; set; }
        public Cor Cor { get; set; }
        public Porte Porte { get; set; }
        public string Observacao { get; set; }
        public Status Status{ get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
