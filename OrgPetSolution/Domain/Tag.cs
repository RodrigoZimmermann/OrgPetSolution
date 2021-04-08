using System.Collections.Generic;

namespace Domain
{
    public class Tag
    {
        public int ID { get; set; }
        public string Descricao { get; set; }

        //Automaticamente faz com que o EntityFramework traga todos os animais que tem esta tag
        public virtual ICollection<Animal> Animais { get; set; }
    }
}
