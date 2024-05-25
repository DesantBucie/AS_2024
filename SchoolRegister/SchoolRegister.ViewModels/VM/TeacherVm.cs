using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class TeacherVm
    {
        public string TeacherName { get; set; } = null!;

        public IList<SubjectVm> Subjects { get; set; } = null!;
    }
}
