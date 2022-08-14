using ITalent_EFCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalent_EFCore.Models
{
    internal class Location
    {
        public int Id { get; set; }
        public Cities City { get; set; }
        public ICollection<Employee> employees { get; set; } = new List<Employee>();

    }
}
