using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace GameEngine.Web.Controllers
{
	public abstract class BaseController : Controller
	{
		protected readonly ILogger Logger;
		protected readonly IMapper Mapper;
		public BaseController(ILogger logger, IMapper mapper) {
			Logger = logger;
			Mapper = mapper;
		}
	}
}
