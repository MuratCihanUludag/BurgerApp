using AutoMapper;
using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerApp.PL.CommonFunctions;

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
            var cipsDtoList = _manager.GetAll();
            var cipsViewList = _mapper.Map<List<CipsViewModel>>(cipsDtoList);
            return View(cipsViewList);
        }

        public IActionResult Edit(int id)
        {
            var cipsDTO = _manager.GetById(id);
            var cipsView = _mapper.Map<CipsViewModel>(cipsDTO);
            return PartialView(cipsView);
        }
    }
}
