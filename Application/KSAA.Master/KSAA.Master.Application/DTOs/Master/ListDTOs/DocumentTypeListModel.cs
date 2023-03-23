﻿using KSAA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.Master.ListDTOs
{
    public class DocumentTypeListModel
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
}
