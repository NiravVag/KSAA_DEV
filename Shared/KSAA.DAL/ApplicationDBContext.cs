using KSAA.Domain.Entities;
using KSAA.Domain.Entities.AdvanceRecAdj;
using KSAA.Domain.Entities.ClientRegister;
using KSAA.Domain.Entities.DocumentUpload;
using KSAA.Domain.Entities.FinalOutputRegister;
using KSAA.Domain.Entities.FunctionMaster;
using KSAA.Domain.Entities.GL_Income;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Entities.OutputRegister;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.DAL
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, IdentityUserClaim<long>, ApplicationUserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
         : base(options)
        {
        }
        //DbSet<UserType> tbl_UserType { get; set; }
        DbSet<DocumentType> DocumentTypes { get; set; }
        DbSet<PlantCode> PlantCodes { get; set; }
        DbSet<TaxCode> TaxCodes { get; set; }
        DbSet<CustomerCode> CustomerCodes { get; set; }
        DbSet<VendorCode> VendorCodes { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<TBTagging> TBTaggings { get; set; }
        DbSet<GLIncome_Mapping> GLIncome_Mappings { get; set; }
        DbSet<Functions> Functions { get; set; }
        DbSet<FunctionModule> FunctionModule { get; set; }
        DbSet<GLIncomeRegister> GLIncomeRegisters { get; set; }
        DbSet<SupplyRegister> SupplyRegister { get; set; }
        DbSet<ClientAuthorizedSignatory> ClientAuthorizedSignatories { get; set; }
        DbSet<ClientBankAccount> ClientBankAccounts { get; set; }
        DbSet<ClientManagingDirector> ClientManagingDirectors { get; set; }
        DbSet<ClientRegistration> ClientRegistrations { get; set; }
        DbSet<ClientServicesGoods> ClientServicesGoods { get; set; }
        DbSet<AdvanceMapping> AdvanceMappings { get; set; }
        DbSet<GSTOutputLiabilityCodes> GSTOutputLiabilityCodes { get; set; }
        DbSet<EInvoiceRegister> EInvoiceRegister { get; set; }
        DbSet<EWayBillRegister> EWayBillRegister { get; set; }
        DbSet<AdvanceReceived> AdvanceReceived { get; set; }
        DbSet<AdvanceAmendment> AdvanceAmendment { get; set; }
        public DbSet<OutputRegister> OutputRegisters { get; set; }
        DbSet<AdvanceAdjustment> AdvanceAdjustment { get; set; }
        DbSet<FinalOutputRegister> FinalOutputRegisters { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("Users");
            });

            builder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("Roles");
            });

            builder.Entity<ApplicationUserRole>(b =>
            {
                b.ToTable("UserRoles");
                b.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
                b.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
            });

            builder.Entity<IdentityUserToken<long>>(b =>
            {
                b.ToTable("UserTokens");
            });

            builder.Entity<IdentityUserClaim<long>>(b =>
            {
                b.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<long>>(b =>
            {
                b.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<long>>(b =>
            {
                b.ToTable("RoleClaims");
            });
            builder.Entity<UserType>(b =>
            {
                b.ToTable("tbl_UserType");
            });

            builder.Entity<Company>(b =>
            {
                b.ToTable("tbl_Company");
            });

            builder.Entity<DocumentType>(b =>
            {
                b.ToTable("tbl_Document_Type");
            });

            builder.Entity<PlantCode>(b =>
            {
                b.ToTable("tbl_Plant_Code");
            });
            builder.Entity<TaxCode>(b =>
            {
                b.ToTable("tbl_Tax_Code");
            });
            builder.Entity<CustomerCode>(b =>
            {
                b.ToTable("tbl_Customer_Code");
            });
            builder.Entity<VendorCode>(b =>
            {
                b.ToTable("tbl_Vendor_Code");
            });
            builder.Entity<Location>(b =>
            {
                b.ToTable("tbl_Location");
            });
            builder.Entity<TBTagging>(b =>
            {
                b.ToTable("tbl_TBTagging");
            });
            builder.Entity<GLIncome_Mapping>(b =>
            {
                b.ToTable("tbl_GL_Income_Mapping");
            });
            //builder.Entity<GL_IncomeData>(b =>
            //{
            //    b.ToTable("tbl_Contrl_Sheet_GL_Inc_Supply_Reg");
            //});
            builder.Entity<Functions>(b =>
            {
                b.ToTable("tbl_Functions");
            });
            builder.Entity<FunctionModule>(b =>
            {
                b.ToTable("tbl_Functions_Modules");
            });

            builder.Entity<GLIncomeRegister>(b =>
            {
                b.ToTable("tbl_Monthly_GL_Income_Register");
            });
            builder.Entity<SupplyRegister>(b =>
            {
                b.ToTable("tbl_Monthly_Supply_Register");
            });
            builder.Entity<EInvoiceRegister>(b =>
            {
                b.ToTable("tbl_E_Invoice_Register");
            });
            builder.Entity<EWayBillRegister>(b =>
            {
                b.ToTable("tbl_E_Way_Bill_Register");
            });
            builder.Entity<LiabilityLedger>(b =>
            {
                b.ToTable("tbl_Liability_Ledger");
            });

            builder.Entity<ClientAuthorizedSignatory>(b =>
            {
                b.ToTable("tbl_Client_Authorized_Signatory");
            });
            builder.Entity<ClientBankAccount>(b =>
            {
                b.ToTable("tbl_Client_Bank_Account");
            });
            builder.Entity<ClientManagingDirector>(b =>
            {
                b.ToTable("tbl_Client_Managing_Director");
            });
            builder.Entity<ClientRegistration>(b =>
            {
                b.ToTable("tbl_Client_Registration");
            });
            builder.Entity<ClientServicesGoods>(b =>
            {
                b.ToTable("tbl_Client_Services_Goods");
            });
            builder.Entity<AdvanceMapping>(b =>
            {
                b.ToTable("tbl_Advance_Mapping");
            });
            builder.Entity<GSTOutputLiabilityCodes>(b =>
            {
                b.ToTable("tbl_GST_Output_Liability_Codes");
            });
            builder.Entity<AdvanceReceived>(b =>
            {
                b.ToTable("tbl_Advance_Received_Module");
            });
            builder.Entity<AdvanceAmendment>(b =>
            {
                b.ToTable("tbl_Advance_Received_Module_Amendment");
            });
            builder.Entity<OutputRegister>(b =>
            {
                b.ToTable("Tbl_Comparison_Report_SL_E_Invoice_E_Way");
            });
            builder.Entity<FinalOutputRegister>(b =>
            {
                b.ToTable("tbl_Final_Output_Register_KSAA_Template");
            });
        }
    }
}
