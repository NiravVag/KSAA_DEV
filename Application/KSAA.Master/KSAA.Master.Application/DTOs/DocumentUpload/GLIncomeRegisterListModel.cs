using KSAA.Domain.Entities.DocumentUpload;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_Monthly_GL_Income_Register")]
    public class GLIncomeRegisterListModel
    {
        public List<GLIncomeRegisterViewModel> gLIncomeRegistersList { get; set; }
        
    }
}
