namespace BUGZ.Models
{
    public class ViewModelForTheAbminWhenViewingAllUsers
    {
        public IEnumerable<UserBundle> UserBundles { get; set; }
        public class UserBundle
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public IEnumerable<string> Roles { get; set; }
        }
    }
}
