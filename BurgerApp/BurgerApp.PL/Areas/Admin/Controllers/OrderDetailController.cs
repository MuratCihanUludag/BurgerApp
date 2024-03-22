using AutoMapper;
using BurgerApp.BLL.Manager.Concrete.GeneralManager;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderDetailController : Controller
    {
        private readonly OrderDetailManager _manager;
        private readonly IMapper _mapper;

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
            var orderDetailDtoList = _manager.GetAll();
            var orderDetailViewList = _mapper.Map<List<OrderDetailViewModel>>(orderDetailDtoList);
            ViewBag.OrderDetailViewList = orderDetailViewList;
            return PartialView("_OrderDetailTable", orderDetailViewList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_AddOrderDetail");
        }
        [HttpPost]
        public IActionResult Add(OrderDetailViewModel orderDetail)
        {
            if (ModelState.IsValid)
            {
                var orderDetailDto = _mapper.Map<OrderDetailDTO>(orderDetail);
                _manager.Add(orderDetailDto);
                return RedirectToAction("Index");
            }
            return PartialView("_AddOrderDetail", orderDetail);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var orderDetailDto = _manager.GetById(id);
            var orderDetailView = _mapper.Map<OrderDetailViewModel>(orderDetailDto);
            return PartialView("_EditOrderDetail", orderDetailView);
        }
        [HttpPost]
        public IActionResult Edit(OrderDetailViewModel orderDetail)
        {
            if (ModelState.IsValid)
            {
                var orderDetailDto = _mapper.Map<OrderDetailDTO>(orderDetail);
                _manager.Update(orderDetailDto);
                return RedirectToAction("Index");
            }
            return PartialView("_EditOrderDetail", orderDetail);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var orderDetailDto = _manager.GetById(id);
            var orderDetailView = _mapper.Map<OrderDetailViewModel>(orderDetailDto);
            return PartialView("_DeleteOrderDetail", orderDetailView);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _manager.Delete(new OrderDetailDTO { Id = id });
            return RedirectToAction("Index");
        }
    }
}
