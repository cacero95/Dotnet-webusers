namespace webusers.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string? ModuleName { get; set; }
        public int ModuleIndex { get; set; }
        public User? User { get; set; }
    }
}