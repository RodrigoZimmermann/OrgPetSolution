using Domain;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
   public class UsuarioMapConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapConfig()
        {
            this.ToTable("Usuario");
            this.Property(p => p.Senha).HasMaxLength(15);
        }
    }
}
