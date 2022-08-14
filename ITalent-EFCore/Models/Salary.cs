using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalent_EFCore.Models
{
    internal class Salary
    {
        public int EmpId { get; set; }
        public int SalaryAmount { get; set; }
        public int PrizeAmount { get; set; }
        public Employee Employee { get; set; }
    }
}
