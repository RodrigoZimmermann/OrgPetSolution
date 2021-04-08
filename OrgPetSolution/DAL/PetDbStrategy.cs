using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PetDbStrategy : DropCreateDatabaseIfModelChanges<PetContext>
    {
        protected override void Seed(PetContext context)
        {
            using (PetContext ctx = new PetContext())
            {
                //Cliente c = new Cliente();
                //c.Nome = "Ricardo Schmidt";
                //c.Telefone = "47999994499";
                //c.Email = "ricardo.schmidt@gmail.com";
                //c.DataNascimento = new DateTime(2003, 4, 11);
                //c.CPF = "90191706949";
                //ctx.Clientes.Add(c);

                //Fornecedor f = new Fornecedor();
                //f.CNPJ = "12345678901234";
                //f.Contato = "Davi";
                //f.Email = "max@gmail.com";
                //f.NomeFantasia = "Max";
                //f.RazaoSocial = "Max Ltda";
                //f.Telefone = "4730351099";

                //Produto p = new Produto();
                //p.Nome = "Red Box";
                //p.Preco = 12;
                //p.UnidadeMedida = DataTypeObject.Enums.UnidadeMedida.Unitario;
                //p.Estoque = 100;
                //p.Descricao = "teste";
                //p.Fornecedor = f;

                //ctx.Fornecedores.Add(f);
                //ctx.Produtos.Add(p);

                ctx.SaveChanges();

            }
            base.Seed(context);
        }
    }
}
