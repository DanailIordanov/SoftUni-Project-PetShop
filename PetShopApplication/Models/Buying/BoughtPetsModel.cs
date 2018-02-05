namespace PetShopApplication.Models.Buying
{
    using System;

    public class BoughtPetsModel
    {
        public decimal Price { get; set; }

        public DateTime BoughtOn { get; set; }

        public string PetName { get; set; }

        public string PetImageUrl { get; set; }
    }
}