using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class UsersBonuses
    {
        public string ApplicationUserId { get; set; }
        public string BonusId { get; set; }
    }
}
