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
            var extraMaterialViewList = _mapper.Map<List<ExtraMaterialViewModel>>(extraMaterialDtoList);
            return PartialView(extraMaterialViewList);
        }
        [HttpPost]
        public IActionResult Add(ExtraMaterialViewModel extraMaterial)
        {
            var extraMaterialDto = _mapper.Map<ExtraMaterialDTO>(extraMaterial);

            _manager.Add(extraMaterialDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult _Edit(int id)
        {
            var extraMaterialDto = _manager.GetById(id);
            var extraMaterialView = _mapper.Map<ExtraMaterialViewModel>(extraMaterialDto);

            return PartialView(extraMaterialView);
        }
        [HttpPost]
        public IActionResult _Edit(ExtraMaterialViewModel extraMaterial)
        {
            if (extraMaterial.Image is null)
            {
                var extraMaterialDto = _manager.GetById(extraMaterial.Id);
                extraMaterial.Image = CommonFunc.ArrayToImage(extraMaterialDto.Image);
            }

            if (ModelState.IsValid)
            {
                var extraMaterialDto = _mapper.Map<ExtraMaterialDTO>(extraMaterial);
                _manager.Update(extraMaterialDto);
                return RedirectToAction("Index");
            }
            return PartialView(extraMaterial);
        }

        [HttpGet]
        public IActionResult _Delete(int id)
        {
            var extraMaterialDto = _manager.GetById(id);
            var extraMaterialView = _mapper.Map<ExtraMaterialViewModel>(extraMaterialDto);
            return PartialView(extraMaterialView);
        }
        [HttpPost]
        public IActionResult _Delete(ExtraMaterialViewModel extraMaterial)
        {
            if (extraMaterial.Id is not 0)
            {
                _manager.Delete(_manager.GetById(extraMaterial.Id));
                return RedirectToAction("Index");
            }
            return PartialView(extraMaterial);
        }
    }
}
