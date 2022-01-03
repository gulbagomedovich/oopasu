using OOPASU.Domain;
using System.Collections.Generic;

namespace OOPASU.Infrastructure.Repository
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetClasses();
        Class GetClassByID(int classId);
        void AddClass(Class c);
        void UpdateClass(int id, Class newClass);
        void DeleteClass(int classId);
    }
}
