using System.Collections.Generic;

namespace OOPASU.Domain
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public List<Class> Classes { get; set; }
    }
}
