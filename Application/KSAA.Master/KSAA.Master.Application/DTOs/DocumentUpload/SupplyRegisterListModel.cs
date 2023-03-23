using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_Monthly_Supply_Register")]
    public class SupplyRegisterListModel
    {
        public List<SupplyRegisterViewModel> supplyRegistersList { get; set; }
    }
}
