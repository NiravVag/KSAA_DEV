using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.DocumentUpload
{
    [Table("tbl_E_Way_Bill_Register")]
    public class EWayBillRegister : BaseEntity
    {
        public virtual string? ClientCode { get; set; }
        public virtual string? EWBNo { get; set; }
        public virtual DateTime? EWBDate { get; set; }
        public virtual string? SupplyType { get; set; }
        public virtual string? DocNo { get; set; }
        public virtual DateTime? DocDate { get; set; }
        public virtual string? OtherPartyGSTIN { get; set; }
        public virtual string? TransporterDetails { get; set; }
        public virtual string? FromGSTINInfo { get; set; }
        public virtual string? TOGSTINInfo { get; set; }
        public virtual string? Status { get; set; }
        public virtual decimal? NoOfItems { get; set; }
        public virtual string? MainHSNCode { get; set; }
        public virtual string? MainHSNDesc { get; set; }
        public virtual decimal? AssessableValue { get; set; }
        public virtual decimal? SGST { get; set; }
        public virtual decimal? CGST { get; set; }
        public virtual decimal? IGST { get; set; }
        public virtual decimal? CESS { get; set; }
        public virtual decimal? CESSNonAdvol { get; set; }
        public virtual decimal? OtherValue { get; set; }
        public virtual decimal? TotalInvoice { get; set; }
        public virtual DateTime? ValidTillDate { get; set; }
        public virtual string? ModeOfGeneration { get; set; }
        public virtual string? CancelledBy { get; set; }
        public virtual DateTime? CancelledDate { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
    }
}
