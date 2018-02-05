namespace PetShopApplication.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Range(1,50)]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public string AnimalType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Breed { get; set; }

        //in BGN
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsBought { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public Coat Coat { get; set; }

        public string Characteristics { get; set; }

        public string OwnerId { get; set; }
        
        public virtual User Owner { get; set; }
    }
}