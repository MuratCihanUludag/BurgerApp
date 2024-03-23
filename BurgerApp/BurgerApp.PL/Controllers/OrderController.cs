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
    public class OrderController : Controller
    {
        private readonly OrderManager _manager;
        private IMapper _mapper;
        public OrderController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new OrderManager(dbContext);
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetTableList()
        {
            var orderDtoList = _manager.GetAll();
            var orderViewList = _mapper.Map<List<OrderViewModel>>(orderDtoList);
            return PartialView(orderViewList);
        }
        
        [HttpPost]
        public IActionResult Add(OrderViewModel orderModel)
        {
            if(ModelState.IsValid)
            {
                var orderDto = _mapper.Map<OrderDTO>(orderModel);
                _manager.Add(orderDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return PartialView(_mapper.Map<OrderViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Edit(OrderViewModel orderModel)
        {
            if (ModelState.IsValid)
            {
                var orderDto = _mapper.Map<OrderDTO>(orderModel);
                _manager.Update(orderDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(_mapper.Map<OrderViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Delete(OrderViewModel orderModel)
        {
            if (orderModel.Id is not 0)
            {
                _manager.Delete(_manager.GetById(orderModel.Id));
                return Ok();
            }
            return BadRequest();
        }
    }
}
