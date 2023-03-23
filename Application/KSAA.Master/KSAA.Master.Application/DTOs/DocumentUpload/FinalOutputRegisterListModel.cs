using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_Final_Output_Register_KSAA_Template")]
    public class FinalOutputRegisterListModel
    {
        public List<FinalOutputRegisterViewModel> finalOutputRegistersList { get; set; }
    }
}
