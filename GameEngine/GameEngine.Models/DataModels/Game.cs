using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Model.DataModels
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime PublishDate {  get; set; }
        public virtual Engine Engine { get; set; } = null!;
        public int? EngineId { get; set; }
    }
}
