using AutoMapper;
using BurgerApp.BLL.Manager.Concrete.GeneralManager;
using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.Manager.Concrete.Other_Managers;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.Data;
using BurgerApp.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BurgerApp.PL.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly OrderDetailManager _manager;
        private readonly BurgerManager _burgerManager;
        private readonly DrinkManager _drinkManager;
        private readonly CipsManager _cipsManager;
        private readonly MenuManager _menuManager;
        private readonly SauceManager _sauceManager;
        private IMapper _mapper;

        public OrderDetailController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new OrderDetailManager(dbContext);
            _mapper = mapper;
            _burgerManager = new BurgerManager(dbContext);
            _drinkManager = new DrinkManager(dbContext);
            _cipsManager = new CipsManager(dbContext);
            _menuManager = new MenuManager(dbContext);

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var admin = HttpContext.User.FindAll(ClaimTypes.Role).Where(x => x.Value == "Admin").FirstOrDefault();
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userId;
            IList<OrderDetailDTO> orderdetailDtoList;

            if (admin is not null)
            {
                orderdetailDtoList = _manager.GetAll();
            }
            else
            {
                orderdetailDtoList = _manager.GetAll().Where(x => x.UserId == userId).ToList();
            }

            var burgers = _burgerManager.GetAll();
            var burgerViewList = _mapper.Map<List<BurgerViewModel>>(burgers);

            var drinks = _drinkManager.GetAll();
            var drinkViewList = _mapper.Map<List<DrinkViewModel>>(drinks);
            var cips = _cipsManager.GetAll();
            var cipsViewList = _mapper.Map<List<CipsViewModel>>(cips);

            var menuList = _menuManager.GetAll();
            var menuViewList = _mapper.Map<List<MenuViewModel>>(menuList);


            var orderdetailViewList = _mapper.Map<List<OrderDetailViewModel>>(orderdetailDtoList);


            ViewBag.Burgers = burgerViewList;
            ViewData["Burger2"] = burgerViewList;
            ViewBag.Drinks = drinkViewList;
            ViewBag.Cips = cipsViewList;
            ViewBag.Menus = menuList;

            return PartialView(orderdetailViewList);
        }
        [HttpPost]
        public IActionResult Add(OrderDetailViewModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                var orderDetailDto = _mapper.Map<OrderDetailDTO>(orderDetailModel);
                _manager.Add(orderDetailDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var orderDetailDto = _manager.GetById(id);
            var orderDetailView = _mapper.Map<OrderDetailViewModel>(orderDetailDto);
            return PartialView(orderDetailView);
        }

        [HttpPost]
        public IActionResult Edit(OrderDetailViewModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                var orderDetailDto = _mapper.Map<OrderDetailDTO>(orderDetailModel);
                _manager.Update(orderDetailDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(_mapper.Map<OrderDetailViewModel>(_manager.GetById(id)));
        }
        [HttpGet]
        public IActionResult CustomizeOrder(int id)
        {
            var orderDetail = _manager.GetById(id);
            if (orderDetail == null)
            {
                return NotFound("Sipariş detayı bulunamadı.");
            }
            ViewBag.Burgers = _mapper.Map<List<BurgerViewModel>>(_burgerManager.GetAll());
            ViewBag.Drinks = _mapper.Map<List<DrinkViewModel>>(_drinkManager.GetAll());
            ViewBag.Chips = _mapper.Map<List<CipsViewModel>>(_cipsManager.GetAll());
            //ViewBag.Sauces = _mapper.Map<List<SauceViewModel>>(_sauceManager.GetAll());

            return PartialView("_CustomizeOrder", orderDetail);
        }

        [HttpPost]
        public IActionResult SaveCustomization(OrderDetailViewModel customizedOrder)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return BadRequest(errors);
            }
            var orderToUpdate = _mapper.Map<OrderDetailDTO>(customizedOrder);

            // OrderDetailDTO ve Sauce, ExtraMaterial sınıfları arasındaki ilişkiyi düzenliyoruz.
            //orderToUpdate.Sauces = _mapper.Map<ICollection<Sauce>>(customizedOrder.Sauces);
            orderToUpdate.ExtraMetarials = _mapper.Map<ICollection<ExtraMaterial>>(customizedOrder.ExtraMetarials);
            _manager.Update(orderToUpdate);

            return Ok();
        }
    }
}
