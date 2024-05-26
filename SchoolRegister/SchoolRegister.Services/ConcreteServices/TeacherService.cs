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
        public TeacherService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper, UserManager<User> userManager) 
            : base(dbContext, logger, mapper) {
            _userManager = userManager;
        }

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
            try
            {
                var User = DbContext.Users
                    .OfType<Teacher>()
                    .FirstOrDefault(t => t.Id == getTeachersGroups.TeacherId);
                if (User == null)
                {
                    throw new ArgumentNullException($"Data Model is null");
                }
                if (_userManager.IsInRoleAsync(User, "Teacher").Result)
                {
                    if (getTeachersGroups == null) 
                    { 
                        throw new ArgumentNullException($"View Model is null"); 
                    }
                    var groups = DbContext.Groups.AsQueryable();
                    groups = groups.Where(g => g.SubjectGroups.Any(sg => sg.Subject.TeacherId == getTeachersGroups.TeacherId));
                    
                    var groupVms = Mapper.Map<IEnumerable<GroupVm>>(groups);
                    return groupVms;
                }
                else { throw new TypeAccessException("Access denied"); }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null!)
        {
            try
            {
                var teacherEntities = DbContext.Users
                    .OfType<Teacher>()
                    .AsQueryable();

                if (filterPredicate == null)
                    throw new ArgumentNullException("FilterPredicate is null");

                teacherEntities = teacherEntities.Where(filterPredicate);

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
