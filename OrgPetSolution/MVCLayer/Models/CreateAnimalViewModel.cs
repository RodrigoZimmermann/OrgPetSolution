using Domain;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLayer.Models
{
    public class CreateAnimalViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Raça Raça { get; set; }
        public HttpPostedFileBase ImagemAnimal { get; set; }
        public Genero Genero { get; set; }
        public bool EhCastrado { get; set; }
        public Cor Cor { get; set; }
        public Porte Porte { get; set; }
        public string Observacao { get; set; }

    }
}