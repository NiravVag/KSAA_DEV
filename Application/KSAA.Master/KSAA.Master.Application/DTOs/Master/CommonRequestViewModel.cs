using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.Master
{
    public  class CommonRequestViewModel
    {
        public long Id { get; set; }
        public List<string> Months { get; set; }
        public List<string> Years { get; set; }
    }
}
