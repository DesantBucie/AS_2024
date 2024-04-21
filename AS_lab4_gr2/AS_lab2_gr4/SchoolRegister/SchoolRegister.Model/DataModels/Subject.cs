using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // 1 *
        public virtual IList<SubjectGroup>? SubjectGroups { get; set; }
        // * 1
        public virtual Teacher? Teacher { get; set; }
        public int TeacherId { get; set; }
        // 1 * 
        public virtual IList<Grade>? Grades { get; set; }
    }
}
