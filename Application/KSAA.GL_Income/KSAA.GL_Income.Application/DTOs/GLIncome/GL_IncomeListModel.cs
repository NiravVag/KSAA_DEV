using KSAA.Domain.Entities.GL_Income;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.GLIncome
{
    public class GL_IncomeListModel
    {
        public List<GL_IncomeData> GL_IncomeData { get; set; }
        public decimal Sum_GL { get; set; }
        public decimal Sum_supply { get; set; }
        public decimal diff { get; set; }
        public List<SupplyModel> SupplyModels { get; set; }
    }
}
