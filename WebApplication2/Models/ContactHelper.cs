using WebApplication2.Service;

namespace WebApplication2.Models
{
    public class ContactHelper
    {
        [key]
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Server { get; set; }
        public string UserId { get; set; }

    }
}
