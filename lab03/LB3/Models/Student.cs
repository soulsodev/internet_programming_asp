using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lab03.Models
{
    public class Student
    {
        public Student() { }

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        [NotMapped]
        public HateoasLinks _links;
    }
}