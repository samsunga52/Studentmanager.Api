using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Business.Student;
using StudentManagement.Business.Subject;
using StudentManagement.Business.User;
using StudentManagement.Interface.IExternalUser;
using StudentManagement.Interface.IStudent;
using StudentManagement.Interface.ISubject;

namespace StudentManagement.Business.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureTransient(this IServiceCollection services)
        {
            services.AddTransient<IStudents, StudentBusiness>();
            services.AddTransient<ISubject, SubjectBusiness>();
            services.AddTransient<IExternalUser, UserBusiness>();
        }
    }
}
