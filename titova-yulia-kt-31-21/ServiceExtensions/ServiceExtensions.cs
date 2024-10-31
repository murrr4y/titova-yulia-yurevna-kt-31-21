using titova_yulia_kt_31_21.Interfaces.GroupInterfaces;
using titova_yulia_kt_31_21.Interfaces.TestInterfaces;
using titova_yulia_kt_31_21.Interfaces.ExamInterfaces;
using titova_yulia_kt_31_21.Interfaces.StudentInterfaces;
using titova_yulia_kt_31_21.Interfaces.SubjectInterfaces;

namespace titova_yulia_kt_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();

            return services;
        }
    }
}
