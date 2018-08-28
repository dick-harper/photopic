using photopic.domain.Attributes;

namespace photopic.domain
{
    [CollectionName("users")]
    public class User : BaseDocument
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginId { get; set; }
        public string PasswordHash { get; set; }
        public bool Active { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
    }
}