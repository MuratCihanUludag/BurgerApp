using AutoMapper;
using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;

namespace BurgerApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CipsController : Controller
    {

        private readonly CipsManager _manager;
        private IMapper _mapper;


        public CipsController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new CipsManager(dbContext);
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()

        {
            var cipsDtoList = _manager.GetAll();
            var cipsModelList = _mapper.Map<List<CipsViewModel>>(cipsDtoList);
            ViewBag.CipsList = cipsModelList;
            return PartialView();
        }
        [HttpPost]

        public IActionResult Add(CipsViewModel cipsModel)
        {
            if (ModelState.IsValid)
            {
                var cipsDto = _mapper.Map<CipsDTO>(cipsModel);
                _manager.Add(cipsDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cipsDTO = _manager.GetById(id);
            var cipsView = _mapper.Map<CipsViewModel>(cipsDTO);
            return PartialView(cipsView);
        }
        [HttpPost]
        public IActionResult Edit(CipsViewModel cipsModel)
        {
            if (cipsModel.Image is null)
            {
                var cipsDto = _manager.GetById(cipsModel.Id);
                cipsModel.Image = CommonFunc.ArrayToImage(cipsDto.Image);
                ModelState.Remove(nameof(cipsModel.Image));
            }
            if (ModelState.IsValid)
            {
                var cipsDto = _mapper.Map<CipsDTO>(cipsModel);
                _manager.Update(cipsDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(_mapper.Map<CipsViewModel>(_manager.GetById(id)));
        }
        [HttpPost]
        public IActionResult Delete(CipsViewModel cipsModel)
        {
            if (cipsModel.Id is not 0)
            {
                _manager.Delete(_manager.GetById(cipsModel.Id));
                return Ok("Index");
            }
            return BadRequest();
        }

    }
}
