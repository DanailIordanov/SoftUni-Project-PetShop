namespace PetShopApplication.Models.Pets
{
    public class ListingPetModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string ImageUrl { get; set; }

        public bool IsBought { get; set; }

        public decimal Price { get; set; }
    }
}