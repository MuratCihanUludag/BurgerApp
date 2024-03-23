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
            _burgerManager = new BurgerManager(dbContext);
            _drinkManager = new DrinkManager(dbContext);
            _cipsManager = new CipsManager(dbContext);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var menuList = _menuManager.GetAll();

            var burgerDtoList = _burgerManager.GetAll();
            var burgerViewList = _mapper.Map<List<BurgerViewModel>>(burgerDtoList);
            var drinkDtoList = _drinkManager.GetAll();
            var drinkViewList = _mapper.Map<List<DrinkViewModel>>(drinkDtoList);
            var cipDtoList = _cipsManager.GetAll();
            var cipsViewList = _mapper.Map<List<CipsViewModel>>(cipDtoList);

            var menuDtoList = _menuManager.GetAll();
            var menuViewList = _mapper.Map<List<MenuViewModel>>(menuDtoList);

            ViewBag.Burgers = burgerViewList;
            ViewBag.Drinks = drinkViewList;
            ViewBag.Cips = cipsViewList;

            return PartialView(menuViewList);
        }
        [HttpPost]
        public IActionResult Add(MenuViewModel menuModel)
        {
            if (ModelState.IsValid)
            {
                var menuDto = _mapper.Map<MenuDTO>(menuModel);
                _menuManager.Add(menuDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var burgerDtoList = _burgerManager.GetAll();
            var burgerViewList = _mapper.Map<List<BurgerViewModel>>(burgerDtoList);
            var drinkDtoList = _drinkManager.GetAll();
            var drinkViewList = _mapper.Map<List<DrinkViewModel>>(drinkDtoList);
            var cipDtoList = _cipsManager.GetAll();
            var cipsViewList = _mapper.Map<List<CipsViewModel>>(cipDtoList);

            ViewBag.Burgers = burgerViewList;
            ViewBag.Drinks = drinkViewList;
            ViewBag.Cips = cipsViewList;


            var menuDto = _menuManager.GetById(id);
            var menuView = _mapper.Map<MenuViewModel>(menuDto);

            return PartialView(menuView);
        }
        [HttpPost]
        public IActionResult Edit(MenuViewModel menuModel)
        {
            if (menuModel.Image is null)
            {
                var menuDto = _menuManager.GetById(menuModel.Id);
                menuModel.Image = CommonFunc.ArrayToImage(menuDto.Image);
                ModelState.Remove(nameof(menuModel.Image));
            }
            if (ModelState.IsValid)
            {
                var menuDto = _mapper.Map<MenuDTO>(menuModel);
                _menuManager.Update(menuDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(_mapper.Map<MenuViewModel>(_menuManager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Delete(MenuViewModel menu)
        {
            if (menu.Id is not 0)
            {
                _menuManager.Delete(_menuManager.GetById(menu.Id));
                return Ok();
            }
            return BadRequest();
        }
    }
}
