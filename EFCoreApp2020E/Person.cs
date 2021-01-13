using System.ComponentModel.DataAnnotations;

namespace EFCoreApp2020E
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        public string Surname { get; set; }

        public string GivenName { get; set; }
    }
}
