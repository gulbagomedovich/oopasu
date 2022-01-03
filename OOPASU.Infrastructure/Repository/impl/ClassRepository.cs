using OOPASU.Domain;
using System.Collections.Generic;
using System.Linq;

namespace OOPASU.Infrastructure.Repository.impl
{
    public class ClassRepository : IClassRepository
    {
        private Context context;

        public ClassRepository(Context context)
        {
            this.context = context;
        }

        public IEnumerable<Class> GetClasses()
        {
            return context.Classes.ToList();
        }

        public Class GetClassByID(int classId)
        {
            return context.Classes.Find(classId);
        }

        public void AddClass(Class c)
        {
            context.Classes.Add(c);

            context.SaveChanges();
        }

        public void UpdateClass(int id, Class newClass)
        {
            Class c = context.Classes.Find(id);
            c.Topic = newClass.Topic;
            c.StartDate = newClass.StartDate;
            c.EndDate = newClass.EndDate;
            c.Status = newClass.Status;
            c.GroupId = newClass.GroupId;
            c.TeacherId = newClass.TeacherId;
            c.ClassRoomId = newClass.ClassRoomId;
            c.DisciplineId = newClass.DisciplineId;
            c.Visits = newClass.Visits;
            c.Students = newClass.Students;
            context.Classes.Update(c);

            context.SaveChanges();
        }

        public void DeleteClass(int classId)
        {
            Class c = context.Classes.Find(classId);
            context.Classes.Remove(c);

            context.SaveChanges();
        }
    }
}
