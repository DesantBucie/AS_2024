using AutoMapper;
using GameEngine.DAL.EF;
using GameEngine.Model.DataModels;
using GameEngine.ViewModels.VM;
using GameEngines.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameEngines.Services.ConcreteServices
{
    public class EngineService : BaseService, IEngineService
    {
        public EngineService(AppDbContext ctx, IMapper mapper, ILogger logger) : base(ctx, mapper, logger)
        {
        }

        public EngineVm AddOrUpdateEngineVm(AddOrUpdateEngineVm addOrUpdateEngineVm)
        {
            try
            {
                if (addOrUpdateEngineVm == null)
                {
                    throw new ArgumentNullException("Datamodel is null");
                }
                var engineEntity = mapper.Map<Engine>(addOrUpdateEngineVm);
                if (addOrUpdateEngineVm.Id == 0)
                {
                    ctx.Engines.Add(engineEntity);
                }
                else
                    ctx.Engines.Update(engineEntity);
                ctx.SaveChanges();

                var engineVm = mapper.Map<EngineVm>(engineEntity);
                return engineVm;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public EngineVm GetEngineVm(int id)
        {
            var e = ctx.Engines.FirstOrDefault(engine => engine.Id == id);
            var engineVm = mapper.Map<EngineVm>(e);
            return engineVm;
        }


        public IEnumerable<EngineVm> GetAllEnginesVm()
        {
            var engineEntities = ctx.Engines;
            var engines = mapper.Map<IEnumerable<EngineVm>>(engineEntities);

            return engines;
        }

		public void DeleteEngineVm(int id)
		{
			var e = ctx.Engines.FirstOrDefault(e => e.Id == id);
            ctx.Engines.Remove(e);
            ctx.SaveChanges();
		}
	}
}
