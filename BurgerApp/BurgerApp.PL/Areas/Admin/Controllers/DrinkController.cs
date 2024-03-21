using AutoMapper;
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
        private readonly DrinkManager _drinkManager;
        private readonly IMapper _mapper;

        public DrinkController(BurgerAppContext context, IMapper mapper)
        {
            _drinkManager = new DrinkManager(context);
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var drinks = _drinkManager.GetAll();
            var model = _mapper.Map<IEnumerable<DrinkViewModel>>(drinks);
            return View(model);
        }
        public IActionResult DrinkList()
        {
            var drinks = _drinkManager.GetAll();
            var model = _mapper.Map<IEnumerable<DrinkViewModel>>(drinks);
            return PartialView("_DrinkList", model);
        }
        public IActionResult Details(int id)
        {
            var drink = _drinkManager.GetById(id);
            if (drink == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<DrinkViewModel>(drink);
            return PartialView("_Details", model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageBytes = null;
                if (model.Image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.Image.CopyToAsync(memoryStream);
                        imageBytes = memoryStream.ToArray();
                    }
                }

                var drinkDto = _mapper.Map<DrinkDTO>(model);
                drinkDto.Image = imageBytes;

                _drinkManager.Add(drinkDto);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var drink = _drinkManager.GetById(id);
            var model = _mapper.Map<DrinkViewModel>(drink);
            return PartialView("_Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DrinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                var drinkDto = _mapper.Map<DrinkDTO>(model);
                _drinkManager.Update(drinkDto);
                return RedirectToAction("DrinkList");
            }
            return PartialView("_Edit", model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var drink = _drinkManager.GetById(id);
            var model = _mapper.Map<DrinkViewModel>(drink);
            return PartialView("_Delete", model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _drinkManager.Delete(new DrinkDTO { Id = id });
            return RedirectToAction("DrinkList");
        }
    }
}

