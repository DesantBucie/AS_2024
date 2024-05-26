using Microsoft.AspNetCore.Mvc;
using GameEngines.Services.Interfaces;
using Microsoft.Extensions.Localization;
using AutoMapper;
using GameEngine.ViewModels.VM;
namespace GameEngine.Web.Controllers
{
	public class EngineController : BaseController
	{
		private readonly IEngineService _engineService;
		public EngineController(
			IEngineService engineService, ILogger logger, IMapper mapper) 
			: base(logger, mapper)
		{
			_engineService = engineService;
		}

		public IActionResult Index()
		{
			
			return View(_engineService.GetAllEnginesVm());
		}
		public IActionResult AddUpdate(int id=-1)
		{
			if (id == -1)
				return View();

			var e = _engineService.GetEngineVm(id);
			var engine = Mapper.Map<AddOrUpdateEngineVm>(e);
			return View(engine);

			
		}
		public IActionResult Delete(int id)
		{
			var e = (_engineService.GetEngineVm(id));
			return View(e);
		}
		[HttpPost]
		public IActionResult AddUpdate(AddOrUpdateEngineVm vm)
		{
			if (ModelState.IsValid) {
				_engineService.AddOrUpdateEngineVm(vm);
			}
			return(RedirectToAction("Index"));
		}
		[HttpPost]
		public IActionResult Delete(IFormCollection FC)
		{
			var id = int.Parse(FC["EngineId"]);
			 _engineService.DeleteEngineVm(id);

			return RedirectToAction("Index");
		}
	}
}
