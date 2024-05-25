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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Services.ConcreteServices
{
    public class TeacherService : BaseService, ITeacherService
    {
        private UserManager<User> _userManager;
        public TeacherService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper) 
            : base(dbContext, logger, mapper) {}

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate)
        {
            try
            {
                if (filterPredicate == null)
                    throw new ArgumentNullException("Filter predicate is null");

                var teacherEntity = DbContext.Users
                    .OfType<Teacher>()
                    .FirstOrDefault(filterPredicate);
                var teacherVm = Mapper.Map<TeacherVm>(teacherEntity);
                return teacherVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        

        public IEnumerable<GroupVm> GetTeacherGroups(TeachersGroupsVm getTeachersGroups)
        {
            if (getTeachersGroups == null)
                throw new ArgumentNullException("getTeachersGroups is null");
            
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null)
        {
            try
            {
                var teacherEntities = DbContext.Users
                    .OfType<Teacher>()
                    .AsQueryable();

                if (filterPredicate == null)
                    throw new ArgumentNullException("FilterPredicate is null");

                var teacherVms = Mapper.Map<IEnumerable<TeacherVm>>(teacherEntities);
                return teacherVms;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
