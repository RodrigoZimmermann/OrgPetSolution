using System.Data.Entity;

namespace DAL
{
    public class PetDbStrategy : DropCreateDatabaseIfModelChanges<PetContext>
    {
        protected override void Seed(PetContext context)
        {
            using (PetContext ctx = new PetContext())
            {
                ctx.SaveChanges();
            }
            base.Seed(context);
        }
    }
}
