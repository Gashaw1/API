using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VocDbContext
{
    [Table("Definitions")]
    public class Definitions
    {
        public Definitions()
        {

        }
        [Required]
        [Key]
        public int definitionsID { get; set; }
        //Foregin key
        public int vocabularyID { get; set; }
        public string definition { get; set; }        
    }
}