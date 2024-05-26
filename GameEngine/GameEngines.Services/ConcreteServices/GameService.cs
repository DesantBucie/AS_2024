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
    public class GameService : BaseService, IGameService
    {
        public GameService(AppDbContext ctx, IMapper mapper, ILogger logger) : base(ctx, mapper, logger)
        {
        }

        public GameVm AddOrUpdateGameVm(AddOrUpdateGameVm addOrUpdateGameVm)
        {
            try
            {
                if(addOrUpdateGameVm == null)
                {
                    throw new ArgumentNullException("DataModel is null");
                }
                var gameEntity = mapper.Map<Game>(addOrUpdateGameVm);
                var engine = ctx.Engines.FirstOrDefault(e => e.Id == gameEntity.EngineId);
                if(engine == null)
                {
                    throw new ArgumentNullException("Engine is null"); 
                }
                gameEntity.Engine = engine;
                if (addOrUpdateGameVm.Id == 0)
                {
                    ctx.Games.Add(gameEntity);
                }
                else
                {
                    ctx.Games.Update(gameEntity);
                }
                ctx.SaveChanges();

                var gameVm = mapper.Map<GameVm>(gameEntity);
                
                return gameVm;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

		public void DeleteGameVm(int id)
		{
            var game = ctx.Games.FirstOrDefault(g => g.Id == id);
            ctx.Games.Remove(game);
            ctx.SaveChanges();
		}

		public IEnumerable<EngineVm> GetAllEnginesVm()
		{
			var engineEntities = ctx.Engines;
			var engines = mapper.Map<IEnumerable<EngineVm>>(engineEntities);

			return engines;
		}

		public IEnumerable<GameVm> GetAllGamesVm()
        {
            try
            {
      
                var gameEntities = ctx.Games;

                var games = mapper.Map<IEnumerable<GameVm>>(gameEntities);
                return games;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message); 
                throw;
            }
        }

		public GameVm GetGameVm(int id)
		{
			return mapper.Map<GameVm>(ctx.Games.FirstOrDefault(g => g.Id == id));
		}
	}
}
