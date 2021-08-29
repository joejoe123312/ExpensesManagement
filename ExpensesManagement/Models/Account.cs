using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string firstanme { get; set; }
        [Required]
        public string middlename { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public int CredentialsId { get; set; }
    }
}
