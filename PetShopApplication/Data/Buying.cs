namespace PetShopApplication.Data
{
    using System;

    public class Buying
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime BoughtOn { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }
    }
}