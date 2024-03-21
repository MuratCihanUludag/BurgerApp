using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;

namespace BurgerApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BurgerController : Controller
    {
        private readonly BurgerManager _manager;
        private IMapper _mapper;
        public BurgerController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new BurgerManager(dbContext);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var burgerDtoList = _manager.GetAll();
            var burgerViewList = _mapper.Map<List<BurgerViewModel>>(burgerDtoList);
            ViewBag.burgerViewList = burgerViewList;
            return PartialView();
        }

        [HttpPost]
        public IActionResult Add(BurgerViewModel burger)
        {
            if (ModelState.IsValid)
            {
                var burgerDto = _mapper.Map<BurgerDTO>(burger);
                _manager.Add(burgerDto);
            }
            return PartialView("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var burgerDto = _manager.GetById(id);
            var burgerView = _mapper.Map<BurgerViewModel>(burgerDto);

            return PartialView(burgerView);
        }
        [HttpPost]
        public IActionResult Edit(BurgerViewModel burger)
        {
            if (burger.Image is null)
            {
                var burgerDto = _manager.GetById(burger.Id);
                burger.Image = CommonFunc.ArrayToImage(burgerDto.Image);
            }

            if (ModelState.IsValid)
            {
                var burgerDto = _mapper.Map<BurgerDTO>(burger);
                _manager.Update(burgerDto);
                return RedirectToAction("Index");
            }
            return PartialView(burger);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var burgerDto = _manager.GetById(id);
            var burgerView = _mapper.Map<BurgerViewModel>(burgerDto);
            return PartialView(burgerView);
        }
        [HttpPost]
        public IActionResult Delete(BurgerViewModel burger)
        {
            if (burger.Id is not 0)
            {
                _manager.Delete(_manager.GetById(burger.Id));
                return RedirectToAction("Index");
            }
            return PartialView(burger);
        }
    }
}
