using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_E_Way_Bill_Register")]
    public class EWayBillRegisterViewModel
    {
        public long Id { get; set; }
        public string? ClientCode { get; set; }
        public string? EWBNo { get; set; }
        public string? EWBDate { get; set; }
        public string? SupplyType { get; set; }
        public string? DocNo { get; set; }
        public string? DocDate { get; set; }
        public string? OtherPartyGSTIN { get; set; }
        public string? TransporterDetails { get; set; }
        public string? FromGSTINInfo { get; set; }
        public string? TOGSTINInfo { get; set; }
        public string? Status { get; set; }
        public decimal? NoOfItems { get; set; }
        public string? MainHSNCode { get; set; }
        public string? MainHSNDesc { get; set; }
        public decimal? AssessableValue { get; set; }
        public decimal? SGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? IGST { get; set; }
        public decimal? CESS { get; set; }
        public decimal? CESSNonAdvol { get; set; }
        public decimal? OtherValue { get; set; }
        public decimal? TotalInvoice { get; set; }
        public string? ValidTillDate { get; set; }
        public string? ModeOfGeneration { get; set; }
        public string? CancelledBy { get; set; }
        public string? CancelledDate { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
}
