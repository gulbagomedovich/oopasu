namespace OOPASU.Domain
{
    public class Visit
    {
        public string Status { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
