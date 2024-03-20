using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;

namespace BurgerApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BurgerController : Controller
    {
        private readonly BurgerManager _manager;
        public BurgerController(BurgerAppContext dbContext)

        {
            _manager = new BurgerManager(dbContext);

        }
        public async Task<IActionResult> Index()
        {
            var burgers = _manager.GetAll();
            var burgerViewList = new List<BurgerViewModel>();
            foreach (var item in burgers)
            {
                var burger = new BurgerViewModel();

                burger.Name = item.Name;
                burger.Description = item.Description;
                burger.Price = item.Price;
                burger.Image = await CommonFunc.ArrayToImage(item.Image);
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
        public async Task<IActionResult> Add(BurgerViewModel burger)
        {
            if (burger is not null)
            {
                BurgerDTO burgerDTO = new BurgerDTO();
                burgerDTO.Name = burger.Name;
                burgerDTO.Description = burger.Description;
                burgerDTO.Image = await CommonFunc.ImageToArray(burger.Image);
                burgerDTO.Price = burger.Price;

                _manager.Add(burgerDTO);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
