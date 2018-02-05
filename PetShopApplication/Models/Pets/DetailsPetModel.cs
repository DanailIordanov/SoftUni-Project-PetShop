using PetShopApplication.Data;

namespace PetShopApplication.Models.Pets
{
    public class DetailsPetModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public string AnimalType { get; set; }
        
        public string Breed { get; set; }
        
        public decimal Price { get; set; }
        
        public string ImageUrl { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }
        
        public Coat Coat { get; set; }

        public string Characteristics { get; set; }

        public bool IsBought { get; set; }

        public string ContactInformation { get; set; }
    }
}