using Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace DAL
{
    public class PetContext : DbContext
    {
        public PetContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\PetOrg.mdf;Integrated Security=True;Connect Timeout=30")
        {
            //USADO APENAS PARA AMBIENTE DE DESENVOLVIMENTO
            //APAGAR OU COMENTAR ESTA LINHA ANTES DE JOGAR O CÓDIGO PRA PRODUÇÃO
            Database.SetInitializer(new PetDbStrategy());
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Animal> Animais { get; set; }


        //Método que determina como a base é criada de acordo com os DbSets registrados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Criação da configuração global que diz que as strings gerarão VARCHAR NOT NULL
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string))
                        .Configure(c => c.IsRequired().IsUnicode(false));

            //Criação da configuração global que determina o comportamento padrão do campo CPF
            //CHAR(11)
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper() == "CPF")
                        .Configure(c => c.IsFixedLength().HasMaxLength(11));

            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper() == "NOME")
                        .Configure(c => c.IsFixedLength().HasMaxLength(70));

            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper() == "CEP")
                        .Configure(c => c.IsFixedLength().HasMaxLength(8));

            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper() == "EMAIL")
                        .Configure(c => c.HasMaxLength(150));

            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper().Contains("TELEFONE"))
                        .Configure(c => c.HasMaxLength(15));

            modelBuilder.Properties()
                 .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper().Contains("CELULAR"))
                 .Configure(c => c.HasMaxLength(15));

            modelBuilder.Properties()
                 .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper().Contains("ENDERECO"))
                 .Configure(c => c.HasMaxLength(100));

            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(DateTime))
                        .Configure(c => c.IsRequired().HasColumnType("datetime2"));

            //Como criar convenção de Handle como chave primária de identidade
            //modelBuilder.Properties()
            //          .Where(c => c.PropertyType == typeof(int) && c.Name == "Handle").Configure(c => c.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
            //          //Ignora a técnica de Pluralização de nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Adicionar todos os maps configs do projeto DAL
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            //Chamada padrão de criação da base
            base.OnModelCreating(modelBuilder);
        }
    }
}
