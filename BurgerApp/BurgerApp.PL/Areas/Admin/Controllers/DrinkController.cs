using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerApp.PL.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class DrinkController : Controller
    {
        private readonly DrinkManager _manager;

        public DrinkController(BurgerAppContext dbContext)
        {
            _manager = new DrinkManager(dbContext);
        }
        public IActionResult Index()
        {
            var drinks = _manager.GetAll();
            return View(drinks);
        }
        public IActionResult Details(int id)
        {
            var drink = _manager.GetById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                var drinkDTO = new DrinkDTO
                {
                    Name = model.Name,
                    Size = model.Size,
                    Price = model.Price,
                    Image = await CommonFunc.ImageToArray(model.Image)
                };
                _manager.Add(drinkDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var drink = _manager.GetById(id);
            if (drink == null)
            {
                return NotFound();
            }
            var model = new DrinkViewModel
            {

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DrinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var drink = _manager.GetById(id);
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
            var drink = _manager.GetById(id); 
            if (drink != null)
            {
                _manager.Delete(drink); 
                return RedirectToAction(nameof(Index));
            }
            return NotFound(); 
        }
    }
}

