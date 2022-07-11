using DocLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static DocLibrary.Model.Common.Enums;

namespace DocLibrary.Entity.Entities
{
    public class Document : BaseEntity
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        [Required]
        public DocumentType DocumentType { get; set; }
        [Required]
        public DocumentExtension DocumentExtension { get; set; }
        [Required]
        public string DocumentName { get; set; }
        [Required]
        public DateTime UploadTime { get; set; }
        [Required]
        public byte[] Content { get; set; }

        public virtual User User { get; set; }
    }
}
