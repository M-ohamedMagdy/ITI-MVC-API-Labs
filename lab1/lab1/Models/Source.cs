namespace lab1.Models
{
    public enum Status
    {
        Table, List
    }
    public class Source
    {
        public Status source;
        public Car? car;
    }
}
