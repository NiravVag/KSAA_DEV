using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_Liability_Ledger")]
    public class LiabilityLedgerListModel
    {
        public List<LiabilityLedgerViewModel> liabilityLedgersList { get; set; }
    }
}
