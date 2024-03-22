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
        public IActionResult Add(BurgerViewModel burgerModel)
        {
            if (ModelState.IsValid)
            {
                var burgerDto = _mapper.Map<BurgerDTO>(burgerModel);
                _manager.Add(burgerDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return PartialView(_mapper.Map<BurgerViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Edit(BurgerViewModel burgerModel)
        {
            if (burgerModel.Image is null)
            {
                var burgerDto = _manager.GetById(burgerModel.Id);
                burgerModel.Image = CommonFunc.ArrayToImage(burgerDto.Image);
                ModelState.Remove(nameof(burgerModel.Image));
            }

            if (ModelState.IsValid)
            {
                var burgerDto = _mapper.Map<BurgerDTO>(burgerModel);
                _manager.Update(burgerDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(_mapper.Map<BurgerViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Delete(BurgerViewModel burgerModel)
        {
            if (burgerModel.Id is not 0)
            {
                _manager.Delete(_manager.GetById(burgerModel.Id));
                return Ok();
            }
            return BadRequest();
        }
    }
}
