using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeNetCore.Models
{
    public class SystemUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}
