using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using AutoMapper;

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
            var burgers = _manager.GetAll();
            var burgerViewList = new List<BurgerViewModel>();

            foreach (var item in burgers)
            {
                var burger = _mapper.Map<BurgerViewModel>(item);
                burgerViewList.Add(burger);
            }
            return View(burgerViewList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BurgerViewModel burger)
        {
            var burgerDto = _mapper.Map<BurgerDTO>(burger);

            _manager.Add(burgerDto);

            return RedirectToAction(nameof(Index));
        }
    }
}
