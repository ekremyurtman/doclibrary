using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocLibrary.Helper.HttpHandlerHelper
{
    public interface IHttpHandler
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, object obj);
    }
}
