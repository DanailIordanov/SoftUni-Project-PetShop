namespace PetShopApplication.Data
{
    using System.ComponentModel.DataAnnotations;

    public enum Coat
    {
        [Display(Name = "None")]
        No,
        [Display(Name = "Short Hair")]
        Short,
        [Display(Name = "Medium Lenght Hair")]
        Medium,
        [Display(Name = "Long Hair")]
        Long
    }
}