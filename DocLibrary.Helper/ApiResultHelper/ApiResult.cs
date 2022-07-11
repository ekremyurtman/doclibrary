using System;
using System.Collections.Generic;
using System.Text;

namespace DocLibrary.Helper.ApiResultHelper
{
    public class ApiResult
    {
        public bool Result { get; set; } = true;
        public string Message { get; set; }
        public int? HttpStatusCode { get; set; } = 200;
        public string ExceptionCode { get; set; }
    }

    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }
}
