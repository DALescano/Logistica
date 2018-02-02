using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public class StatusResponse
    {
        public StatusResponse()
        {
            Messages = new List<string>();
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
    }

    public class StatusResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
    }
}
