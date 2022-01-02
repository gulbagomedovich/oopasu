using System.Collections.Generic;

namespace OOPASU.Domain
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsCertified { get; set; }
        public int Grade { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public ICollection<Class> Classes { get; set; }
        public List<Visit> Visits { get; set; }
    }
}
