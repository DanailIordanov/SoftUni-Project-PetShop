namespace PetShopApplication.Migrations
{
    using Data;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "PetShopApplication.Data.PetShopDbContext";
        }

        protected override void Seed(PetShopDbContext context)
        {
            if (context.Pets.Any())
            {
                return;
            }

            var user = context.Users.FirstOrDefault();

            if (user == null)
            {
                return;
            }

            context.Pets.Add(new Pet
            {
                Name = "Akira",
                Age = 4,
                AnimalType = "Dog",
                Breed = "Husky",
                Price = 1000,
                ImageUrl = "http://www.huskycolors.com/images/black/BlackTess.jpg",
                Color = "Black",
                Size = "Big",
                Coat = Coat.Long,
                Characteristics = "Rare",
                OwnerId = user.Id
            });
            
            context.Pets.Add(new Pet
            {
                Name = "Kitty",
                Age = 3,
                AnimalType = "Cat",
                Breed = "Siamese",
                Price = 600,
                ImageUrl = "http://buzzsharer.com/wp-content/uploads/2015/07/Siamese-Cat-beauty.jpg",
                Color = "Grey",
                Size = "Medium",
                Coat = Coat.Short,
                Characteristics = "Loving",
                OwnerId = user.Id
            });

            context.Pets.Add(new Pet
            {
                Name = "Bunny",
                Age = 5,
                AnimalType = "Rabbit",
                Breed = "Jersey Wooly",
                Price = 300,
                ImageUrl = "http://www.petguide.com/wp-content/uploads/2016/06/jersey-wooly.jpeg",
                Color = "Grey",
                Size = "Medium",
                Coat = Coat.Medium,
                Characteristics = "Cute",
                OwnerId = user.Id
            });

            context.Pets.Add(new Pet
            {
                Name = "Arthur",
                Age = 1,
                AnimalType = "Dog",
                Breed = "Yorkshire Terrier",
                Price = 800,
                ImageUrl = "https://www.pets4homes.co.uk/images/breeds/20/large/917d77fa7e0070d0e219ba59ff770ade.jpg",
                Color = "Black",
                Size = "Small",
                Coat = Coat.Short,
                Characteristics = "Fluffy",
                OwnerId = user.Id
            });

            context.Pets.Add(new Pet
            {
                Name = "Tiger",
                Age = 2,
                AnimalType = "Cat",
                Breed = "Bengal",
                Price = 700,
                ImageUrl = "http://img.huffingtonpost.com/asset/,scalefit_600_noupscale/57bb618a1700001108c74c1b.jpeg",
                Color = "Orange and Black",
                Size = "Medium",
                Coat = Coat.Short,
                Characteristics = "Exotic",
                OwnerId = user.Id
            });
        }
    }
}
