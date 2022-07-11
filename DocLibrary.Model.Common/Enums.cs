using System;
using System.Collections.Generic;
using System.Text;

namespace DocLibrary.Model.Common
{
    public class Enums
    {
        public enum DocumentType
        {
            Pdf = 1,
            Word,
            Excel,
            Text,
            Picture
        }

        public enum DocumentExtension
        {
            pdf = 1,
            doc,
            docx,
            xls,
            xlsx,
            txt,
            jpg,
            jpeg,
            png
        }

        public enum DocumentShareType
        {
            Minute = 1,
            Hourly,
            Daily
        }
    }
}
