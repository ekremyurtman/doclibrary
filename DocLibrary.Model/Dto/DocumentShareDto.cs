using System;
using System.Collections.Generic;
using System.Text;

namespace DocLibrary.Model.Dto
{
    public class DocumentShareDto
    {
        public long UserId { get; set; }
        public long DocumentId { get; set; }
        public DateTime ShareStartTime { get; set; }
        public short ShareTypeCode { get; set; }
        public string ShareTypeName { get; set; }
        public int ShareTotalDuration { get; set; }
        public string ShareRef { get; set; }
    }
}
