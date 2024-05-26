using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class StudentVm
    {
        public string GroupName { get; set; } = string.Empty;
        public int? GroupId { get; set; }

        public IList<GradeVm>? Grades { get; set; }

        public string ParentName { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public GroupVm Group { get; set; } = null!;
    }
}
