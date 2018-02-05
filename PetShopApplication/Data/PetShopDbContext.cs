namespace PetShopApplication.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class PetShopDbContext : IdentityDbContext<User>
    {
        public PetShopDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Pet> Pets { get; set; }

        public virtual IDbSet<Buying> BoughtPets { get; set; }

        public object Buyings { get; internal set; }

        public static PetShopDbContext Create()
        {
            return new PetShopDbContext();
        }
    }
}