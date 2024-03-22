using AutoMapper;
using BurgerApp.BLL.Manager.Concrete.GeneralManager;
using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.BLL.ViewModels.Menu_Models;
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
        private IMapper _mapper;

        public OrderDetailController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new OrderDetailManager(dbContext);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var orderdetailDtoList = _manager.GetAll();
            var orderdetailViewList = _mapper.Map<List<OrderDetailViewModel>>(orderdetailDtoList);
            ViewBag.drinkList = orderdetailViewList;
            return PartialView();
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
