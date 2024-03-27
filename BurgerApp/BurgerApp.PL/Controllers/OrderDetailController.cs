using AutoMapper;
using BurgerApp.BLL.Manager.Concrete.GeneralManager;
using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.Manager.Concrete.Other_Managers;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.Data;
using BurgerApp.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BurgerApp.PL.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly OrderDetailManager _manager;
        private readonly BurgerManager _burgerManager;
        private readonly DrinkManager _drinkManager;
        private readonly CipsManager _cipsManager;
        private readonly MenuManager _menuManager;
        private readonly SauceManager _sauceManager;
        private readonly ExtraMaterialManager _extraManager;
        private IMapper _mapper;

        public OrderDetailController(BurgerAppContext dbContext, IMapper mapper)
        {
            _manager = new OrderDetailManager(dbContext);
            _mapper = mapper;
            _burgerManager = new BurgerManager(dbContext);
            _drinkManager = new DrinkManager(dbContext);
            _cipsManager = new CipsManager(dbContext);
            _menuManager = new MenuManager(dbContext);

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTableList()
        {
            var admin = HttpContext.User.FindAll(ClaimTypes.Role).Where(x => x.Value == "Admin").FirstOrDefault();
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userId;
            IList<OrderDetailDTO> orderdetailDtoList;

            if (admin is not null)
            {
                orderdetailDtoList = _manager.GetAll();
            }
            else
            {
                orderdetailDtoList = _manager.GetAll().Where(x => x.UserId == userId).ToList();
            }

            var burgers = _burgerManager.GetAll();
            var burgerViewList = _mapper.Map<List<BurgerViewModel>>(burgers);

            var drinks = _drinkManager.GetAll();
            var drinkViewList = _mapper.Map<List<DrinkViewModel>>(drinks);
            var cips = _cipsManager.GetAll();
            var cipsViewList = _mapper.Map<List<CipsViewModel>>(cips);

            var menuList = _menuManager.GetAll();
            var menuViewList = _mapper.Map<List<MenuViewModel>>(menuList);


            var orderdetailViewList = _mapper.Map<List<OrderDetailViewModel>>(orderdetailDtoList);


            ViewBag.Burgers = burgerViewList;
            ViewData["Burger2"] = burgerViewList;
            ViewBag.Drinks = drinkViewList;
            ViewBag.Cips = cipsViewList;
            ViewBag.Menus = menuList;

            return PartialView(orderdetailViewList);
        }
        [HttpPost]
        public IActionResult Add(OrderDetailViewModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                var orderDetailDto = _mapper.Map<OrderDetailDTO>(orderDetailModel);
                _manager.Add(orderDetailDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var orderDetailDto = _manager.GetById(id);
            var orderDetailView = _mapper.Map<OrderDetailViewModel>(orderDetailDto);
            return PartialView(orderDetailView);
        }

        [HttpPost]
        public IActionResult Edit(OrderDetailViewModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                var orderDetailDto = _mapper.Map<OrderDetailDTO>(orderDetailModel);
                _manager.Update(orderDetailDto);
                return Ok();
            }
            var errors = ModelState.GetErrors();
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(_mapper.Map<OrderDetailViewModel>(_manager.GetById(id)));
        }
        //[HttpGet]
        //public IActionResult CustomizeOrder(int id)
        //{
        //    var orderDetail = _manager.GetById(id);
        //    if (orderDetail == null)
        //    {
        //        return NotFound("Sipariş detayı bulunamadı.");
        //    }
        //    ViewBag.Burgers = _mapper.Map<List<BurgerViewModel>>(_burgerManager.GetAll());
        //    ViewBag.Drinks = _mapper.Map<List<DrinkViewModel>>(_drinkManager.GetAll());
        //    ViewBag.Chips = _mapper.Map<List<CipsViewModel>>(_cipsManager.GetAll());
        //    //ViewBag.Sauces = _mapper.Map<List<SauceViewModel>>(_sauceManager.GetAll());

        //    return PartialView("CustomizeOrder", orderDetail);
        //}
        //[HttpGet]
        //public IActionResult CustomizeOrder(int id)
        //{
        //    var orderDetailDto = _manager.GetById(id);
        //    if (orderDetailDto == null)
        //    {
        //        return NotFound("Sipariş detayı bulunamadı.");
        //    }

        //    // Burger, Drink, Chips ve gerekirse Sauces listelerini alıp ViewModel'lere dönüştür
        //    var burgers = _burgerManager.GetAll();
        //    var drinks = _drinkManager.GetAll();
        //    var chips = _cipsManager.GetAll();
        //    // var sauces = _sauceManager.GetAll(); // Eğer Sauce listesi de gerekiyorsa

        //    // Dönüştürülen ViewModel'leri ViewBag ile geçir
        //    ViewBag.Burgers = _mapper.Map<List<BurgerViewModel>>(burgers);
        //    ViewBag.Drinks = _mapper.Map<List<DrinkViewModel>>(drinks);
        //    ViewBag.Chips = _mapper.Map<List<CipsViewModel>>(chips);
        //    // ViewBag.Sauces = _mapper.Map<List<SauceViewModel>>(sauces); // Eğer Sauce listesi de gerekiyorsa

        //    // OrderDetailDTO'yu ViewModel'e dönüştür ve doğrudan model olarak kullan
        //    var orderDetailViewModel = _mapper.Map<OrderDetailViewModel>(orderDetailDto);

        //    // CustomizeOrder PartialView'ini OrderDetailViewModel modeli ve ilgili listelerle çağır
        //    return PartialView("CustomizeOrder", orderDetailViewModel);
        //}
        //[HttpPost]
        //public IActionResult SaveCustomization(OrderDetailViewModel customizedOrder)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.GetErrors();
        //        return BadRequest(errors);
        //    }
        //    var orderToUpdate = _mapper.Map<OrderDetailDTO>(customizedOrder);

        //    // OrderDetailDTO ve Sauce, ExtraMaterial sınıfları arasındaki ilişkiyi düzenliyoruz.
        //    //orderToUpdate.Sauces = _mapper.Map<ICollection<Sauce>>(customizedOrder.Sauces);
        //    orderToUpdate.ExtraMetarials = _mapper.Map<ICollection<ExtraMaterial>>(customizedOrder.ExtraMetarials);
        //    _manager.Update(orderToUpdate);

        //    return Ok();
        //}
        //[HttpGet]
        //public IActionResult CustomizeOrder(int id)
        //{
        //    var orderDetailDto = _manager.GetById(id);
        //    if (orderDetailDto == null)
        //    {
        //        // NotFound mesajını daha anlaşılır hale getirelim.
        //        TempData["ErrorMessage"] = "Sipariş detayı bulunamadı. Lütfen geçerli bir sipariş seçiniz.";
        //        return RedirectToAction("Index"); // veya uygun bir view'a yönlendirme yapabilirsiniz.
        //    }

        //    // ViewModel'leri hazırla
        //    var burgers = _burgerManager.GetAll();
        //    var drinks = _drinkManager.GetAll();
        //    var chips = _cipsManager.GetAll();

        //    ViewBag.Burgers = _mapper.Map<List<BurgerViewModel>>(burgers);
        //    ViewBag.Drinks = _mapper.Map<List<DrinkViewModel>>(drinks);
        //    ViewBag.Chips = _mapper.Map<List<CipsViewModel>>(chips);

        //    var orderDetailViewModel = _mapper.Map<OrderDetailViewModel>(orderDetailDto);
        //    return PartialView("CustomizeOrder", orderDetailViewModel);
        //}
        //[HttpPost]
        //public IActionResult SaveCustomization(OrderDetailViewModel customizedOrder)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.GetErrors(); // ModelState'den gelen hataları bir listeye dönüştür.
        //        TempData["ErrorMessages"] = errors; // Hataları TempData ile bir sonraki istekte kullanmak üzere sakla.
        //        return RedirectToAction("CustomizeOrder", new { id = customizedOrder.Id }); // Kullanıcıyı düzenleme sayfasına geri gönder.
        //    }

        //    var orderToUpdate = _mapper.Map<OrderDetailDTO>(customizedOrder);
        //    _manager.Update(orderToUpdate);

        //    TempData["SuccessMessage"] = "Sipariş başarıyla güncellendi."; // Başarı mesajını sakla.
        //    return RedirectToAction("Index"); // veya uygun bir view'a yönlendirme yapabilirsiniz.
        //}
        //[HttpGet]
        //public IActionResult CustomizeOrder(int menuId)
        //{
        //    var menuDto = _menuManager.GetById(menuId);
        //    var menuView = _mapper.Map<MenuViewModel>(menuDto);

        //    var availableSauces = _sauceManager.GetAll();
        //    var availableDrinks = _drinkManager.GetAll();
        //    var availableBurgers = _burgerManager.GetAll();
        //    var availableCips = _cipsManager.GetAll();
        //    var availableExtras = _extraManager.GetAll();

        //    var customizeOrderViewModel = new CustomizeOrderViewModel
        //    {
        //        SelectedMenu = menuView,
        //        AvailableSauces = _mapper.Map<List<SauceViewModel>>(availableSauces),
        //        AvailableDrinks = _mapper.Map<List<DrinkViewModel>>(availableDrinks),
        //        AvailableBurgers = _mapper.Map<List<BurgerViewModel>>(availableBurgers),
        //        AvailableCips = _mapper.Map<List<CipsViewModel>>(availableCips),
        //        AvailableExtras = _mapper.Map<List<ExtraMaterialViewModel>>(availableExtras)
        //    };

        //    return PartialView("CustomizeOrder", customizeOrderViewModel);
        //}
        //[HttpPost]
        //public IActionResult CustomizeOrder(CustomizeOrderViewModel customizeOrderViewModel)
        //{
        //    // ModelState'in doğru olup olmadığını kontrol et.
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.GetErrors();
        //        return BadRequest(errors);
        //    }

        //    try
        //    {
        //        // Seçilen ögeleri OrderDetailDTO'ya dönüştür.
        //        var orderDetailDto = new OrderDetailDTO
        //        {
        //            BurgerId = customizeOrderViewModel.SelectedMenu.BurgerId,
        //            DrinkId = customizeOrderViewModel.SelectedMenu.DrinkId,
        //            CipsId = customizeOrderViewModel.SelectedMenu.CipsId,
        //            Count = 1, // Varsayılan olarak 1 adet menü sipariş edilmiş varsayıyoruz.
        //            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier), // Giriş yapmış kullanıcının Id'si
        //            Sauces = _mapper.Map<List<Sauce>>(customizeOrderViewModel.AvailableSauces
        //                                    .Where(s => customizeOrderViewModel.SelectedSaucesIds.Contains(s.Id))),
        //            ExtraMetarials = _mapper.Map<List<ExtraMaterial>>(customizeOrderViewModel.AvailableExtras
        //                                    .Where(e => customizeOrderViewModel.SelectedExtrasIds.Contains(e.Id))),
        //            // Diğer gerekli alanlar burada doldurulabilir.
        //        };

        //        // Özelleştirilmiş siparişin toplam fiyatını hesapla.
        //        var totalPrice = orderDetailDto.OrderDetailTotalPrice();

        //        // OrderDetail nesnesini veritabanına ekle.
        //        _manager.Add(orderDetailDto);

        //        // Siparişin başarılı olduğuna dair bir onay mesajı gönder.
        //        return Json(new { success = true, message = "Sipariş başarıyla özelleştirildi ve sepete eklendi!", totalPrice = totalPrice });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Bir hata oluşursa, hatayı döndür.
        //        return BadRequest(new { success = false, message = ex.Message });
        //    }
        //}

    }
}

