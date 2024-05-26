using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Model.DataModels;
using GameEngine.ViewModels.VM;

namespace GameEngines.Services.Interfaces
{
    public interface IGameService
    {
        GameVm AddOrUpdateGameVm(AddOrUpdateGameVm addOrUpdateGameVm);
        GameVm GetGameVm(int id);
        IEnumerable<EngineVm> GetAllEnginesVm();
        void DeleteGameVm(int id);
        IEnumerable<GameVm> GetAllGamesVm();
    }
}
