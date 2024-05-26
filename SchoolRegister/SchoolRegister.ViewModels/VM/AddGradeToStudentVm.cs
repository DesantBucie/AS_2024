using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class AddGradeToStudentVm
    {
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public GradeScale GradeScale { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
