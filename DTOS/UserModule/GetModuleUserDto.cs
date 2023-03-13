namespace webusers.DTOS.UserModule
{
    public class GetModuleUserDto
    {
        public int Id { get; set; }
        public string? ModuleName { get; set; }
        public int ModuleIndex { get; set; }
        public webusers.Models.User? User { get; set; }
    }
}