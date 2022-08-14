using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalent_EFCore.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int TitleId { get; set; }
        public Title Title { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public Salary Salary { get; set; }
        public ICollection<Department> departments { get; set; } = new List<Department>();
    }
}
