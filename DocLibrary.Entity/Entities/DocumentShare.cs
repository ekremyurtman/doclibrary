using DocLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DocLibrary.Model.Common.Enums;

namespace DocLibrary.Entity.Entities
{
    public class DocumentShare : BaseEntity
    {
        public long UserId { get; set; }
        public long DocumentId { get; set; }
        [Required]
        public DateTime ShareStartTime { get; set; }
        [Required]
        public DocumentShareType ShareType { get; set; }
        [Required]
        public int ShareTotalDuration { get; set; }
        [Required]
        public string ShareRef { get; set; }

        public virtual Document Document { get; set; }
        public virtual User User { get; set; }
    }
}
