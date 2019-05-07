using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Bonus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? Amount { get; set; }

        public int? Price { get; set; }
        public DateTime? TimeLimit { get; set; }
    }
}
