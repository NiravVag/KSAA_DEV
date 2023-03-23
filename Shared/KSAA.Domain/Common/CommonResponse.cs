using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Common
{
    public class CommonResponse<T>
    {
        public T Data { get; set; }
        public bool succeeded { get; set; }
        public string message { get; set; }
    }
}
