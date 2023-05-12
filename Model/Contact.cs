using System.ComponentModel.DataAnnotations;

namespace Core_Web_Api.Model
{
    public class Contact
    {
        public int Id { get; set; }    
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }

    }
}
