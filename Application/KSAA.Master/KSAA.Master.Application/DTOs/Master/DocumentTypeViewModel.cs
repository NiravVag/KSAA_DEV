using KSAA.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.Master
{
    public class DocumentTypeViewModel
    {
        public long Id { get; set; }
        public string? BillType { get; set; }
        public string? Document_Code { get; set; }
        public string? Document_Type { get; set; }
        public string? OurSoftwareProcessing { get; set; }
        public string? IP { get; set; }
        public string? BrowserCase { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

    //[Serializable]
    public class DocumentTypeUpload
    {
        //public IFormFile formfile { get; set; }
        public IFormFile file { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string filepath { get; set; }
        public string type { get; set; }
    }

    public class FilePreview
    {
        public string? month { get; set; }
        public string? year { get; set; }
        public string? type { get; set; }
    }
}