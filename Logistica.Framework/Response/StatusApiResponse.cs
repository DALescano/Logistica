using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public class StatusApiResponse
    {        
        public string Message { get; set; }
        public List<string> Messages { get; set; }
        public bool Success { get; set; }
       
    }
}
