using System.Collections.Generic;

namespace OOPASU.Domain
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Code { get; set; }
        public string Specialization { get; set; }
        public List<Class> Classes { get; set; }
        public List<Student> Students { get; set; }
    }
}
