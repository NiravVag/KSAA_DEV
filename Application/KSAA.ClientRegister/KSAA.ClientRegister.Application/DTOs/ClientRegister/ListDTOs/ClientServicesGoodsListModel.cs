using KSAA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs
{
    public class ClientServicesGoodsListModel
    {
        public long Id { get; set; }
        public string? ServicesName { get; set; }
        public string? ServicesCode { get; set; }
        public string? CustomerCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
        public string? IP { get; set; }
        public string? BrowserCase { get; set; }
    }
}
