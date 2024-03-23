using AutoMapper;
using BurgerApp.BLL.Manager.Concrete.Menu_Manager;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerApp.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class DrinkController : Controller
{
    private readonly DrinkManager _manager;
    private IMapper _mapper;
    public DrinkController(BurgerAppContext dbContext, IMapper mapper)
    {
        _manager = new DrinkManager(dbContext);
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult GetTableList()
    {
        var drinkDtoList = _manager.GetAll();
        var drinkViewList = _mapper.Map<List<DrinkViewModel>>(drinkDtoList);
        ViewBag.drinkList = drinkViewList;
        return PartialView();
    }
    [HttpPost]
    public IActionResult Add(DrinkViewModel drinkModel)
    {
        if (ModelState.IsValid)
        {
            var drinkDto = _mapper.Map<DrinkDTO>(drinkModel);
            _manager.Add(drinkDto);
            return Ok();
        }
        var errors = ModelState.GetErrors();
        return BadRequest(errors);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var drinkDto = _manager.GetById(id);
        var drinkView = _mapper.Map<DrinkViewModel>(drinkDto);

        return PartialView(drinkView);
    }
    [HttpPost]
    public IActionResult Edit(DrinkViewModel drinkModel)
    {

        if (drinkModel.Image is null)
        {
            var drinDto = _manager.GetById(drinkModel.Id);
            drinkModel.Image = CommonFunc.ArrayToImage(drinDto.Image);
            ModelState.Remove(nameof(drinkModel.Image));
        }
        if (ModelState.IsValid)
        {
            var drinkDto = _mapper.Map<DrinkDTO>(drinkModel);
            _manager.Update(drinkDto);
            return Ok();
        }
        var errors = ModelState.GetErrors();
        return BadRequest(errors);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        return PartialView(_mapper.Map<DrinkViewModel>(_manager.GetById(id)));
    }
    [HttpPost]
    public IActionResult Delete(DrinkViewModel drink)
    {
        if (drink.Id is not 0)
        {
            _manager.Delete(_manager.GetById(drink.Id));
            return Ok();
        }
        return BadRequest();
    }

}

