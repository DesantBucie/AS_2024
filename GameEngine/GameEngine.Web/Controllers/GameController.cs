using AutoMapper;
using GameEngine.Model.DataModels;
using GameEngine.ViewModels.VM;
using GameEngines.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace GameEngine.Web.Controllers
{
	public class GameController : BaseController
	{
		private readonly IGameService _gameService;
		private readonly IEngineService _engineService;
        public GameController(IGameService gameService, ILogger logger, IMapper mapper, IEngineService engineService) : base(logger, mapper)
		{
			_gameService = gameService;
			_engineService = engineService;
		}

		public IActionResult Index()
		{
			return View(_gameService.GetAllGamesVm());
		}

		public IActionResult AddUpdate(int id = -1)
		{
			var engines =  Mapper.Map<List<Engine>>(_engineService.GetAllEnginesVm());
			var enginesList = engines.Select(e => new SelectListItem { Text = e.Name, Value = e.Id.ToString() });
			
			ViewBag.Engines = enginesList;

			if (id == -1) 
				return View();
			var game = Mapper.Map<AddOrUpdateGameVm>(_gameService.GetGameVm(id));
			return View(game);
		}
		[HttpPost]
		public IActionResult AddUpdate(AddOrUpdateGameVm vm) {
			if(ModelState.IsValid)
			{
				_gameService.AddOrUpdateGameVm(vm);
			}
			return RedirectToAction("Index");
			
		}

		public IActionResult Delete(int id)
		{
			return View(_gameService.GetGameVm(id));
		}
		[HttpPost]
		public IActionResult Delete(IFormCollection FC)
		{
			int id = int.Parse(FC["GameId"]);
			_gameService.DeleteGameVm(id);
			return RedirectToAction("Index");
		}
	}
}
