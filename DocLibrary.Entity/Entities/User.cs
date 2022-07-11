using DocLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DocLibrary.Entity.Entities
{
    public class User : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        [Required]
        public string Surname { get; set; }
        [StringLength(500)]
        [Required]
        public string Address { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
