namespace BUGZ.Models
{
    public class ViewModelForAbminViewOneUser
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
        public IEnumerable<string> OtherRoles { get; set; }
    }
}
