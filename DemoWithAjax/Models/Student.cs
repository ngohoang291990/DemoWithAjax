using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoWithAjax.Models
{
    [Table("Students")]
    public class Student
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Class { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}