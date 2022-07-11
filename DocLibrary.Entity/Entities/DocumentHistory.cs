using DocLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DocLibrary.Entity.Entities
{
    public class DocumentHistory : BaseEntity
    {
        public long DocumentId { get; set; }
        public long UserId { get; set; }
        [Required]
        public DateTime DownloadTime { get; set; }
    }
}
