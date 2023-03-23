using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Parameters
{
    public class RequestPageParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public RequestPageParameter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        public RequestPageParameter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
