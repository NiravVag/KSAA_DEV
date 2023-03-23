using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.GSTR
{
    public class GSTRReplicaViewModel
    {
        public string? NoOfRecords { get; set; }
        public string? GSTRCategory { get; set; }
        public string? GSTRTable { get; set; }
        public string? DocumentType { get; set; }
        public decimal TaxableValue { get; set; }
        public decimal IntegratedTax { get; set; }
        public decimal CentralTax { get; set; }
        public decimal StateTax { get; set; }
        public decimal StateTaxCess { get; set; }
    }
}
