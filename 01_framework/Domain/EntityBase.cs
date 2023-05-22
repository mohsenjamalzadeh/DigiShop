namespace _01_framework.Domain
{
    public class EntityBase
    {
        public long Id { get;private set; }
        public DateTime CreationDate { get;private set; } = DateTime.Now;
        public DateTime ModefiedDate { get; private set; }

    }
}
