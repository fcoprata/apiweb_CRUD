using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_web.Domain.Model.EmployeeAggregate
{
    [Table("employee")]
    public class Employee
    {
        [Column("Id")]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        public string name { get;  set; }

        [Column("Age")]
        [Display(Name = "Age")]
        public int Age { get;  set; }

        [Column("Photo")]
        [Display(Name = "Photo")]
        public string photo { get; private set; }

        public Employee(string name = "", int Age = 00, string photo = "")
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.Age = Age;
            this.photo = photo;
        }

    }
}
