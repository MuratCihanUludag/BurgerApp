using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DrinkController : Controller
    {
        private readonly DrinkManager _drinkManager;
        private readonly ILogger<DrinkController> _logger;

        public DrinkController(BurgerAppContext context, ILogger<DrinkController> logger)
        {
            _drinkManager = new DrinkManager(context);
            _logger = logger; 
        }

        public IActionResult Index()
        {
            var drinks = _drinkManager.GetAll();
            return View(drinks);
        }

        public IActionResult Details(int id)
        {
            var drink = _drinkManager.GetById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrinkDTO drinkDto, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imageFile.CopyToAsync(memoryStream);
                        drinkDto.Image = memoryStream.ToArray();
                    }
                }
                _drinkManager.Add(drinkDto);
                return RedirectToAction(nameof(Index));
            }
            return View(drinkDto);
        }

        public IActionResult Edit(int id)
        {
            var drink = _drinkManager.GetById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DrinkDTO drinkDto, IFormFile imageFile)
        {
            if (id != drinkDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            imageFile.CopyTo(memoryStream);
                            drinkDto.Image = memoryStream.ToArray();
                        }
                    }
                    _drinkManager.Update(drinkDto);
                }
                catch (Exception ex) 
                {
                    _logger.LogError(ex, "Drink güncellenirken bir hata oluştu"); 
                    ModelState.AddModelError("", "Bir hata oluştu ve içecek güncellenemedi. Lütfen daha sonra tekrar deneyiniz.");
                    return View(drinkDto);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(drinkDto);
        }

        public IActionResult Delete(int id)
        {
            var drink = _drinkManager.GetById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var drink = _drinkManager.GetById(id);
            _drinkManager.Remove(drink);
            return RedirectToAction(nameof(Index));
        }
    }
}

