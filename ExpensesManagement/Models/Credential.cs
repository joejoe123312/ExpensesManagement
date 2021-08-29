using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Models
{
    public class Credential
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Username { get; set; }
        [Required]
        [MinLength(1)]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}
