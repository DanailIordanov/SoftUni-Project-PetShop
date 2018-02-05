namespace PetShopApplication.Data
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public User()
        {
            this.Pets = new HashSet<Pet>();
            this.BoughtPets = new HashSet<Buying>();
        }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<Buying> BoughtPets { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}