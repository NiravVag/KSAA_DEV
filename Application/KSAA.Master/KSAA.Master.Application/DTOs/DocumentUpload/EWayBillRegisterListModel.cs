using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_E_Way_Bill_Register")]
    public class EWayBillRegisterListModel
    {
        public List<EWayBillRegisterViewModel> eWayBillRegistersList { get; set; }
    }
}
