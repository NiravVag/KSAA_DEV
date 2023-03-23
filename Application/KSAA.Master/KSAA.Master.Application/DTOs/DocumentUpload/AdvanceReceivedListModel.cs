using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_Advance_Received_Module")]
    public class AdvanceReceivedListModel
    {
        public List<AdvanceReceivedViewModel> advanceReceivedList { get; set; }
    }
}
