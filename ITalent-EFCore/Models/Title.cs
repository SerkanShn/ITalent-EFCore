using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalent_EFCore.Models
{
    internal class Title
    {
        public int Id { get; set; }
        public string TitleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Employee> employees { get; set; } = new List<Employee>();
    }
}
