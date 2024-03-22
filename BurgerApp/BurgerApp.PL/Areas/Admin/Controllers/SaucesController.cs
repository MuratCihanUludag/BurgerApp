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
            ViewBag.sauceViewList = sauceViewList;
            return PartialView();
        }
        [HttpPost]
        public IActionResult Add(SauceViewModel sauce)
        {
            if (ModelState.IsValid)
            {
                _manager.Add(_mapper.Map<SauceDTO>(sauce));
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return PartialView(_mapper.Map<SauceViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Edit(SauceViewModel sauce)
        {
            if (sauce.Image is null)
            {
                var sauceDto = _manager.GetById(sauce.Id);
                sauce.Image = CommonFunc.ArrayToImage(sauceDto.Image);
                ModelState.Remove(nameof(sauce.Image));
            }

            if (ModelState.IsValid)
            {
                var sauceDto = _mapper.Map<SauceDTO>(sauce);
                _manager.Update(sauceDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(_mapper.Map<SauceViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Delete(SauceViewModel sauce)
        {
            if (sauce.Id is not 0)
            {
                _manager.Delete(_manager.GetById(sauce.Id));
                return Ok();
            }
            return BadRequest();
        }
    }
}
