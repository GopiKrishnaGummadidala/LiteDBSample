using System.Collections.Generic;

namespace Carmax.API.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public List<Phone> Phone { get; set; }
        public string Email { get; set; }
    }
}
