using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.ViewModels.VM
{
    public class GameVm
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string EngineName { get; set; } = null!;
        public int EngineId {  get; set; }

    }
}
