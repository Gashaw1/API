using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VocDbContext
{
    [Table("Vocabularys")]
    public class Vocabularys
    {
        public Vocabularys()
        {
        }
        [Required]
        [Key]
        public int vocabularyID { get; set; }
        public string vocabulary { get; set; }
        public int vocPoint { get; set; }
        public string vocInsertedDate { get; set; }
        public DateTime vocPointModifyDate;
        public int UserID { get; set; }
        public List<Definitions> Definitions { get; set; }


        public void Date()
        {
            vocPointModifyDate = DateTime.Now;
        }

        //private string name;
        //public string VocInsertedDateme 
        //{
        //    get
        //    {
        //        return this.vocInsertedDate;
        //    }
        //    set
        //    {
        //        this.vocInsertedDate = DateTime.Now; 
        //    }
        //}
    }

}