namespace PetShopApplication.Controllers
{
    using Data;
    using Microsoft.AspNet.Identity;
    using Models;
    using Models.Buying;
    using Models.Pets;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class PetsController : Controller
    {
        public ActionResult All(int page = 1, string user = null, string search = null)
        {
            var db = new PetShopDbContext();

            var pageSize = 4;

            var petsQuery = db.Pets.AsQueryable();

            if (search != null)
            {
                petsQuery = petsQuery
                    .Where(p => p.Name.ToLower().Contains(search.ToLower()) ||
                        p.Breed.ToLower().Contains(search.ToLower()));
            }
            
            if (user != null)
            {
                petsQuery = petsQuery
                    .Where(p => p.Owner.Email == user);
            }

            var pets = petsQuery
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ListingPetModel
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Age = p.Age,
                    Breed = p.Breed,
                    Price = p.Price,
                    IsBought = p.IsBought
                })
                .ToList();
            
            ViewBag.CurrentPage = page;

            return View(pets);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Buy(BuyPetModel buyPetModel)
        {
            var db = new PetShopDbContext();

            var pet = db.Pets
                .Where(p => p.Id == buyPetModel.PetId)
                .Select(p => new
                {
                    p.IsBought,
                    p.ImageUrl,
                    FullName = p.Name,
                    p.Price
                })
                .FirstOrDefault();

            if (pet == null || pet.IsBought)
            {
                return HttpNotFound();
            }

            buyPetModel.PetName = pet.FullName;
            buyPetModel.Price = pet.Price;
            buyPetModel.ImageUrl = pet.ImageUrl;
            
            return View(buyPetModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Buy(int petId)
        {
            var db = new PetShopDbContext();

            var pet = db.Pets
                .Where(p => p.Id == petId)
                .FirstOrDefault();

            var userId = this.User.Identity.GetUserId();

            if (pet == null || pet.IsBought || pet.OwnerId == userId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var buying = new Buying
            {
                PetId = petId,
                BoughtOn = DateTime.Now,
                UserId = userId,
                Price = pet.Price
            };

            pet.IsBought = true;

            db.BoughtPets.Add(buying);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = pet.Id });
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreatePetModel model)
        {
            if (this.ModelState.IsValid)
            {
                var ownerId = this.User.Identity.GetUserId();

                var pet = new Pet
                {
                    Name = model.Name,
                    Age = model.Age,
                    AnimalType = model.AnimalType,
                    Breed = model.Breed,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    Color = model.Color,
                    Size = model.Size,
                    Coat = model.Coat,
                    Characteristics = model.Characteristics,
                    OwnerId = ownerId
                };

                var db = new PetShopDbContext();
                db.Pets.Add(pet);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = pet.Id });
            }
            return View(model);
        }
        
        [Authorize]
        [HttpGet]
        public ActionResult Delete(DeletePetModel deletePetModel)
        {
            var db = new PetShopDbContext();

            var pet = db.Pets
                .Where(p => p.Id == deletePetModel.Id)
                .Select(p => new
                {
                    p.Name,
                    p.ImageUrl
                })
                .FirstOrDefault();
            
            if (pet == null)
            {
                return HttpNotFound();
            }

            deletePetModel.Name = pet.Name;
            deletePetModel.ImageUrl = pet.ImageUrl;

            return View(deletePetModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var db = new PetShopDbContext();

            var pet = db.Pets
                .Where(p => p.Id == Id)
                .FirstOrDefault();

            var user = this.User.Identity.GetUserId();

            if (pet == null || user != pet.OwnerId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Pets.Remove(pet);
            db.SaveChanges();

            return Redirect("/Pets/All");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var db = new PetShopDbContext();

            var pet = db.Pets
                .Where(p => p.Id == id)
                .First();

            if (pet == null)
            {
                return HttpNotFound();
            }

            var editPetModel = new EditPetModel();

            editPetModel.Name = pet.Name;
            editPetModel.Age = pet.Age;
            editPetModel.AnimalType = pet.AnimalType;
            editPetModel.Breed = pet.Breed;
            editPetModel.ImageUrl = pet.ImageUrl;
            editPetModel.Price = pet.Price;
            editPetModel.Color = pet.Color;
            editPetModel.Size = pet.Size;
            editPetModel.Characteristics = pet.Characteristics;
            editPetModel.Coat = pet.Coat;

            return View(editPetModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(EditPetModel editPetModel)
        {
            if (this.ModelState.IsValid)
            {
                var db = new PetShopDbContext();

                var pet = db.Pets
                    .FirstOrDefault(p => p.Id == editPetModel.Id);
                var ownerId = this.User.Identity.GetUserId();

                pet.Name = editPetModel.Name;
                pet.Age = editPetModel.Age;
                pet.AnimalType = editPetModel.AnimalType;
                pet.Breed = editPetModel.Breed;
                pet.Price = editPetModel.Price;
                pet.ImageUrl = editPetModel.ImageUrl;
                pet.Color = editPetModel.Color;
                pet.Size = editPetModel.Size;
                pet.Coat = editPetModel.Coat;
                pet.Characteristics = editPetModel.Characteristics;

                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details", new { id = editPetModel.Id });
            }

            return View(editPetModel);
        }

        public ActionResult Details(int id)
        {
            var db = new PetShopDbContext();

            var pet = db.Pets
                .Where(p => p.Id == id)
                .Select(p => new DetailsPetModel
                {
                    Id = p.Id,
                    Age = p.Age,
                    AnimalType = p.AnimalType,
                    Breed = p.Breed,
                    Characteristics = p.Characteristics,
                    Coat = p.Coat,
                    Color = p.Color,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price,
                    Size = p.Size,
                    IsBought = p.IsBought,
                    ContactInformation = p.Owner.Email
                })
                .FirstOrDefault();

            if (pet == null)
            {
                return HttpNotFound();
            }
            
            return View(pet);
        }
    }
}