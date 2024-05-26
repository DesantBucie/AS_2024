using GameEngine.Model.DataModels;
using GameEngine.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameEngines.Services.Interfaces
{
    public interface IEngineService
    {
        EngineVm AddOrUpdateEngineVm(AddOrUpdateEngineVm addOrUpdateEngineVm);
        EngineVm GetEngineVm(int id);
        void DeleteEngineVm(int id);
        IEnumerable<EngineVm> GetAllEnginesVm();
    }
}
