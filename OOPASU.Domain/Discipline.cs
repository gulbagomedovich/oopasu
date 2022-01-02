using System.Collections.Generic;

namespace OOPASU.Domain
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string Title { get; set; }
        public List<Class> Classes { get; set; }
    }
}
