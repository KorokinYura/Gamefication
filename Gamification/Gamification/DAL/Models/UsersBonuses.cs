using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class UsersBonuses
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        public int BonusId { get; set; }
    }
}
