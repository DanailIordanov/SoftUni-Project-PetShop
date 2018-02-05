namespace PetShopApplication.Models.Pets
{
    using Infrastructure;
    using PetShopApplication.Data;
    using System.ComponentModel.DataAnnotations;

    public class EditPetModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int OwnerId { get; set; }
        
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        [MaxLength(50)]
        [Display(Name = "Animal Type")]
        public string AnimalType { get; set; }
        
        [MaxLength(50)]
        public string Breed { get; set; }

        //in BGN
        [Display(Name = "Price in BGN")]
        public decimal Price { get; set; }
        
        [Url]
        [ImageUrl]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        [ScaffoldColumn(false)]
        public Coat Coat { get; set; }

        public string Characteristics { get; set; }
    }
}