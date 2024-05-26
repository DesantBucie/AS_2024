using GameEngine.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.ViewModels.VM
{
    public class EngineVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public virtual IList<GameVm> Games { get; set; } = null!;
    }
}
