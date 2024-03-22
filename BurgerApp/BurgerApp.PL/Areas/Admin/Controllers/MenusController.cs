using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.BLL.Manager.Concrete.Other_Managers;
using BurgerApp.PL.Data;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.BLL.Manager.Concrete.GeneralManager;
using BurgerApp.BLL.Manager.Concrete.Menu_Manager;

namespace MenuApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : Controller
    {
        private readonly MenuManager _menuManager;
        private readonly BurgerManager _burgerManager;
        private readonly DrinkManager _drinkManager;
        private readonly CipsManager _cipsManager;
        private IMapper _mapper;
        public MenusController(BurgerAppContext dbContext, IMapper mapper)
        {
            _menuManager = new MenuManager(dbContext);
            _mapper = mapper;
            _burgerManager = new BurgerManager(dbContext);
            _drinkManager = new DrinkManager(dbContext);
            _cipsManager = new CipsManager(dbContext);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var burgers = _burgerManager.GetAll();
            var burgerViewList = _mapper.Map<List<BurgerViewModel>>(burgers);
            var drinks = _drinkManager.GetAll();
            var drinkViewList = _mapper.Map<List<DrinkViewModel>>(drinks);
            var cips = _cipsManager.GetAll();
            var cipsViewList = _mapper.Map<List<CipsViewModel>>(cips);

            var menuDtoList = _menuManager.GetAll();
            var menuViewList = _mapper.Map<List<MenuViewModel>>(menuDtoList);

            ViewBag.Burgers = burgerViewList;
            ViewBag.Drinks = drinkViewList;
            ViewBag.Cips = cipsViewList;

            return PartialView(menuViewList);
        }
        [HttpPost]
        public IActionResult Add(MenuViewModel menu)
        {
            var menuDto = _mapper.Map<MenuDTO>(menu);

            _menuManager.Add(menuDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult _Edit(int id)
        {
            var menuDto = _menuManager.GetById(id);
            var menuView = _mapper.Map<MenuViewModel>(menuDto);

            return PartialView(menuView);
        }
        [HttpPost]
        public IActionResult _Edit(MenuViewModel menu)
        {
            if (ModelState.IsValid)
            {
                var menuDto = _mapper.Map<MenuDTO>(menu);
                _menuManager.Update(menuDto);
                return RedirectToAction("Index");
            }
            return PartialView(menu);
        }

        [HttpGet]
        public IActionResult _Delete(int id)
        {
            var menuDto = _menuManager.GetById(id);
            var menuView = _mapper.Map<MenuViewModel>(menuDto);
            return PartialView(menuView);
        }
        [HttpPost]
        public IActionResult _Delete(MenuViewModel menu)
        {
            if (menu.Id is not 0)
            {
                _menuManager.Delete(_menuManager.GetById(menu.Id));
                return RedirectToAction("Index");
            }
            return PartialView(menu);
        }
    }
}
