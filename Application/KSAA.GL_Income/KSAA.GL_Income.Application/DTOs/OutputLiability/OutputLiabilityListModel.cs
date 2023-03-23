using KSAA.Domain.Entities.GL_Income;
using KSAA.GL_Income.Application.DTOs.OutputSupply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.OutputLiability
{
    public class OutputLiabilityListModel
    {
        public List<GL_IncomeData> GL_IncomeData { get; set; }
        public decimal Sum_GL { get; set; }
        public decimal Sum_supply { get; set; }
        public decimal diff { get; set; }
        public List<SupplyModel> SupplyModels { get; set; }
        public List<OutputSupplyViewModel> outputSupplyLists { get; set; }
        public List<OutputRegisterListModel> outputRegisterModels { get; set; }

        //public decimal Sum_CGSTGL { get; set; }
        //public decimal Sum_SGSTGL { get; set; }
        //public decimal Sum_IGSTGL { get; set; }
        //public decimal Sum_CessGL { get; set; }

        public decimal Sum_CentralTaxSL { get; set; }
        public decimal Sum_StateUTTaxSL { get; set; }
        public decimal Sum_IntegratedTaxSL { get; set; }
        public decimal Sum_CessAmountSL { get; set; }

        public decimal Sum_Difference_CGST { get; set; }
        public decimal Sum_Difference_SGST { get; set; }
        public decimal Sum_Difference_IGST { get; set; }
        public decimal Sum_Difference_Cess { get; set; }
    }
}
