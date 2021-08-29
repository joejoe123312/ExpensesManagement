using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Models
{
    public class Balance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int Money { get; set; }
    }
}
