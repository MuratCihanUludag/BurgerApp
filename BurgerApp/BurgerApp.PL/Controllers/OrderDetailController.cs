using AutoMapper;
using BurgerApp.BLL.Manager.Concrete.GeneralManager;
using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.Data;
using BurgerApp.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.PL.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly OrderDetailManager _manager;
        private readonly BurgerManager _burgerManager;
        private readonly DrinkManager _drinkManager;
        private readonly CipsManager _cipsManager;
        private IMapper _mapper;

        public OrderDetailController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new OrderDetailManager(dbContext);
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

            var orderdetailDtoList = _manager.GetAll();
            var orderdetailViewList = _mapper.Map<List<OrderDetailViewModel>>(orderdetailDtoList);

            ViewBag.Burgers = burgerViewList;
            ViewBag.Drinks = drinkViewList;
            ViewBag.Cips = cipsViewList;

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
    }
}
