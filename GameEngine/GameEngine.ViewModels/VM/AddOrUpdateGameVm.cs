using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.ViewModels.VM
{
    public class AddOrUpdateGameVm
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Publisher { get; set; } = null!;
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int EngineId { get; set; }
    }
}
