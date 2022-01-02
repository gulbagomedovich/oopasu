using System;
using System.Collections.Generic;

namespace OOPASU.Domain
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Topic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public ICollection<Student> Students { get; set; }
        public List<Visit> Visits { get; set; }
    }
}
