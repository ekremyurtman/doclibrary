using System;
using System.Collections.Generic;
using System.Text;

namespace DocLibrary.Model.Dto
{
    public class DocumentDto
    {
        public long UserId { get; set; }
        public long DocumentId { get; set; }
        public short DocumentTypeCode { get; set; }
        public string DocumentTypeName { get; set; }
        public short DocumentExtensionCode { get; set; }
        public string DocumentExtensionName { get; set; }
        public string DocumentName { get; set; }
        public DateTime UploadTime { get; set; }
        public string Content { get; set; }
    }
}
