namespace PetShopApplication.Controllers
{
    using Models.Pets;
    using PetShopApplication.Data;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new PetShopDbContext();

            var pets = db.Pets
                .Where(p => p.IsBought == false)
                .OrderByDescending(p => p.Id)
                .Take(3)
                .Select(p => new ListingPetModel
                {
                    Id = p.Id,
                    Age = p.Age,
                    Breed = p.Breed,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl
                })
                .ToList();

            return View(pets);
        }
    }
}