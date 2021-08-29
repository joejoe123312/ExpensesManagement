using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Expense name")]
        public string ExpenseName { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int AccountId { get; set; }
    }
}
