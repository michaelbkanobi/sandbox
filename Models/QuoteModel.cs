using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuoteMachine.Models
{
    public class QuoteModel
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [Required]
        public string content { get; set; }
        public string author { get; set; }
        public string category1 { get; set; }
        public string category2 { get; set; }
        public decimal rating { get; set; }
    }
}