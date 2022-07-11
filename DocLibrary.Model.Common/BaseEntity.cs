using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DocLibrary.Model.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [DisplayName("PrimaryKey")]
        public long Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
