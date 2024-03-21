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
        private readonly DrinkManager _manager;
        private IMapper _mapper;
        public DrinkController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new DrinkManager(dbContext);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var drinkDtoList = _manager.GetAll();
            var drinkViewList = _mapper.Map<List<DrinkViewModel>>(drinkDtoList);
            ViewBag.drinkList = drinkViewList;
            return PartialView();
        }
        [HttpPost]
        public IActionResult Add(DrinkViewModel drink)
        {
            var drinkDto = _mapper.Map<DrinkDTO>(drink);

            _manager.Add(drinkDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult _Edit(int id)
        {
            var drinkDto = _manager.GetById(id);
            var drinkView = _mapper.Map<DrinkViewModel>(drinkDto);

            return PartialView(drinkView);
        }
        [HttpPost]
        public IActionResult _Edit(DrinkViewModel drink)
        {
            if (drink.Image is null)
            {
                var drinkDto = _manager.GetById(drink.Id);
                drink.Image = CommonFunc.ArrayToImage(drinkDto.Image);
            }

            if (ModelState.IsValid)
            {
                var drinkDto = _mapper.Map<DrinkDTO>(drink);
                _manager.Update(drinkDto);
                return RedirectToAction("Index");
            }
            return PartialView(drink);
        }

        [HttpGet]
        public IActionResult _Delete(int id)
        {
            var drinkDto = _manager.GetById(id);
            var drinkView = _mapper.Map<DrinkViewModel>(drinkDto);
            return PartialView(drinkView);
        }
        [HttpPost]
        public IActionResult _Delete(DrinkViewModel drink)
        {
            if (drink.Id is not 0)
            {
                _manager.Delete(_manager.GetById(drink.Id));
                return RedirectToAction("Index");
            }
            return PartialView(drink);
        }

    }
}

