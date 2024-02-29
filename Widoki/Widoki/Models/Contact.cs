using System.ComponentModel;
namespace Widoki.Models
{
    public class Contact
    {
        [DisplayName("Identyfikator")]
        public int Id { get; set; }
        [DisplayName("Imie")]
        public String Name { get; set; }
        [DisplayName("Nazwisko")]
        public String Surname { get; set; }
        [DisplayName("Email")]
        public String Email { get; set; }
        [DisplayName("Miasto")]
        public String City { get; set; }
        [DisplayName("Numer Telefonu")]
        public String PhoneNumber { get; set; }

        internal int FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
