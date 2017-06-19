using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VocDbContext
{
    [Table("Users")]
    public class Users
    {
        public Users()
        {
        }
        [Required]
        [Key]
        public int UserID { get; set; }      
        public string UserName { get; set; }      
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public List<Vocabularys> Vocabularys { get; set; }
    }
}