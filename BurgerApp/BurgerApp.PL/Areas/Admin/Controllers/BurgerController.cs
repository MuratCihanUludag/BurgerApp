using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BurgerController : Controller
    {
        private BurgerManager _manager;
        public BurgerController(BurgerAppContext dbContext)
        
        {
            _manager = new BurgerManager(dbContext);

        }
        public IActionResult Index()
        {
            var burger = _manager.GetAll();
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BurgerDTO burger)
        {
            _manager.Add(burger);
            return RedirectToAction(nameof(Index));
        }
    }
}
