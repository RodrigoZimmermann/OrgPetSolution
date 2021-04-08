using Domain;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class AnimalMapConfig : EntityTypeConfiguration<Animal>
    {
        public AnimalMapConfig()
        {
            this.ToTable("Animais");
            this.Property(p => p.Raça).HasMaxLength(70);
            this.Property(p => p.Observacao).HasMaxLength(255);
        }
    }
}
