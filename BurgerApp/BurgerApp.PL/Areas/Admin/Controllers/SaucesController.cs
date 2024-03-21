using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.BLL.Manager.Concrete.Other_Managers;
using BurgerApp.PL.Data;

namespace SauceApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SaucesController : Controller
    {
        private readonly SauceManager _manager;
        private IMapper _mapper;
        public SaucesController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new SauceManager(dbContext);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var sauceDtoList = _manager.GetAll();
            var sauceViewList = _mapper.Map<List<SauceViewModel>>(sauceDtoList);
            return PartialView(sauceViewList);
        }
        [HttpPost]
        public IActionResult Add(SauceViewModel sauce)
        {
            var sauceDto = _mapper.Map<SauceDTO>(sauce);

            _manager.Add(sauceDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult _Edit(int id)
        {
            var sauceDto = _manager.GetById(id);
            var sauceView = _mapper.Map<SauceViewModel>(sauceDto);

            return PartialView(sauceView);
        }
        [HttpPost]
        public IActionResult _Edit(SauceViewModel sauce)
        {
            if (sauce.Image is null)
            {
                var sauceDto = _manager.GetById(sauce.Id);
                sauce.Image = CommonFunc.ArrayToImage(sauceDto.Image);
            }

            if (ModelState.IsValid)
            {
                var sauceDto = _mapper.Map<SauceDTO>(sauce);
                _manager.Update(sauceDto);
                return RedirectToAction("Index");
            }
            return PartialView(sauce);
        }

        [HttpGet]
        public IActionResult _Delete(int id)
        {
            var sauceDto = _manager.GetById(id);
            var sauceView = _mapper.Map<SauceViewModel>(sauceDto);
            return PartialView(sauceView);
        }
        [HttpPost]
        public IActionResult _Delete(SauceViewModel sauce)
        {
            if (sauce.Id is not 0)
            {
                _manager.Delete(_manager.GetById(sauce.Id));
                return RedirectToAction("Index");
            }
            return PartialView(sauce);
        }
    }
}
