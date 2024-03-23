using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.BLL.Manager.Concrete.Other_Managers;
using BurgerApp.PL.Data;

namespace ExtraMaterialApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExtraMaterialsController : Controller
    {
        private readonly ExtraMaterialManager _manager;
        private IMapper _mapper;
        public ExtraMaterialsController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new ExtraMaterialManager(dbContext);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var extraMaterialDtoList = _manager.GetAll();
            var extraMaterialModelList = _mapper.Map<List<ExtraMaterialViewModel>>(extraMaterialDtoList);
            ViewBag.extraMaterialModelList = extraMaterialModelList;
            return PartialView();
        }
        [HttpPost]
        public IActionResult Add(ExtraMaterialViewModel extraMaterial)
        {
            if (ModelState.IsValid)
            {
                var extraMaterialDto = _mapper.Map<ExtraMaterialDTO>(extraMaterial);
                _manager.Add(extraMaterialDto);
                return Ok();
            }

            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return PartialView(_mapper.Map<ExtraMaterialViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Edit(ExtraMaterialViewModel extraMaterial)
        {
            if (extraMaterial.Image is null)
            {
                var extraMaterialDto = _manager.GetById(extraMaterial.Id);
                extraMaterial.Image = CommonFunc.ArrayToImage(extraMaterialDto.Image);
                ModelState.Remove(nameof(extraMaterial.Image));
            }

            if (ModelState.IsValid)
            {
                var extraMaterialDto = _mapper.Map<ExtraMaterialDTO>(extraMaterial);
                _manager.Update(extraMaterialDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(_mapper.Map<ExtraMaterialViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Delete(ExtraMaterialViewModel extraMaterial)
        {
            if (extraMaterial.Id is not 0)
            {
                _manager.Delete(_manager.GetById(extraMaterial.Id));
                return Ok();
            }
            return BadRequest();
        }
    }
}
