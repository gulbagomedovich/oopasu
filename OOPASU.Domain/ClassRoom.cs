using System.Collections.Generic;

namespace OOPASU.Domain
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public int Number { get; set; }
        public List<Class> Classes { get; set; }
    }
}
