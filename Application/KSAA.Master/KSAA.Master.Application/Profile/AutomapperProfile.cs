using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.FunctionMaster;
using KSAA.Domain.Entities.Master;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.Features.Commands.TaxCodeCommand;
using KSAA.Master.Application.Features.Master.Commands;
using KSAA.Master.Application.Features.Master.Commands.AdvanceMappingCommand;
using KSAA.Master.Application.Features.Master.Commands.CompanyCommand;
using KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand;
using KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand;
using KSAA.Master.Application.Features.Master.Commands.FunctionCommand;
using KSAA.Master.Application.Features.Master.Commands.FunctionModuleCommand;
using KSAA.Master.Application.Features.Master.Commands.GLIncome_MappingCommand;
using KSAA.Master.Application.Features.Master.Commands.GSTOutputLiabilityCodesCommand;
using KSAA.Master.Application.Features.Master.Commands.LocationCommand;
using KSAA.Master.Application.Features.Master.Commands.PlantCodeCommand;
using KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand;
using KSAA.Master.Application.Features.Master.Commands.VendorCodeCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateDocumentTypeCommand, DocumentType>();
            CreateMap<UpdateDocumentTypeCommand, DocumentType>();
            CreateMap<DocumentType, DocumentTypeViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreatePlantCodeCommand, PlantCode>();
            CreateMap<UpdatePlantCodeCommand, PlantCode>();
            CreateMap<PlantCode, PlantCodeViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateTaxCodeCommand, TaxCode>();
            CreateMap<UpdateTaxCodeCommand, TaxCode>();
            CreateMap<TaxCode, TaxCodeViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateCustomerCodeCommand, CustomerCode>();
            CreateMap<UpdateCustomerCodeCommand, CustomerCode>();
            CreateMap<CustomerCode, CustomerCodeViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateVendorCodeCommand, VendorCode>();
            CreateMap<UpdateVendorCodeCommand, VendorCode>();
            CreateMap<VendorCode, VendorCodeViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();
            CreateMap<Company, CompanyViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateLocationCommand, Location>();
            CreateMap<UpdateLocationCommand, Location>();
            CreateMap<Location, LocationViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateTBTaggingCommand, TBTagging>();
            CreateMap<UpdateTBTaggingCommand, TBTagging>();
            CreateMap<TBTagging, TBTaggingViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateGLIncome_MappingCommand, GLIncome_Mapping>();
            CreateMap<UpdateGLIncome_MappingCommand, GLIncome_Mapping>();
            CreateMap<GLIncome_Mapping, GLIncome_MappingViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateFunctionCommand, Functions>();
            CreateMap<UpdateFunctionCommand, Functions>();
            CreateMap<Functions, FunctionViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateFunctionModuleCommand, FunctionModule>();
            CreateMap<UpdateFunctionModuleCommand, FunctionModule>();
            CreateMap<FunctionModule, FunctionModuleViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateAdvanceMappingCommand, AdvanceMapping>();
            CreateMap<UpdateAdvanceMappingCommand, AdvanceMapping>();
            CreateMap<AdvanceMapping, AdvanceMappingViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateGSTOutputLiabilityCodesCommand, GSTOutputLiabilityCodes>();
            CreateMap<UpdateGSTOutputLiabilityCodesCommand, GSTOutputLiabilityCodes>();
            CreateMap<GSTOutputLiabilityCodes, GSTOutputLiabilityCodesViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();
        }
    }
}
