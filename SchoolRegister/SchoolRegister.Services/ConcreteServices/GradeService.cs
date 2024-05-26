using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Services.ConcreteServices
{
    public class GradeService : BaseService, IGradeService
    {
        private UserManager<User> _userManager;

        public GradeService(ApplicationDbContext dbContext, ILogger logger, 
            IMapper mapper, UserManager<User> userManager) : base(dbContext, logger, mapper)
        {
            _userManager = userManager;
        }

        public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
        {
            try
            {
                if (addGradeToStudentVm == null)
                    throw new ArgumentNullException("AddGradeToStudentVm is null");
                var gradeEntity = Mapper.Map<Grade>(addGradeToStudentVm);
                var studentEntity = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == gradeEntity.StudentId);
                if(_userManager.IsInRoleAsync(studentEntity!, "Student").Result)
                {
                    studentEntity!.Grades!.Add(gradeEntity);
                    DbContext.SaveChanges();
                }
                var GradeVm = Mapper.Map<GradeVm>(gradeEntity);
                return GradeVm;


            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesReportVm)
        {
            try
            {
                if (getGradesReportVm == null)
                    throw new ArgumentNullException("DataModel is null");
                var studentEntity = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == getGradesReportVm.StudentId);
                var gradesReport = new GradesReportVm();
                gradesReport.GradesReport = studentEntity!.GradesPerSubject;

                return gradesReport;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
