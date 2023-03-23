using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.AdvanceRecAdj;
using KSAA.Domain.Entities.DocumentUpload;
using KSAA.Domain.Entities.FinalOutputRegister;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.IAD;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand;
using KSAA.Master.Application.Interfaces.Repositories;
using KSAA.Master.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Shared.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IGenericRepositoryAsync<DocumentType> _documentTypeRepositoryAsync;
        private readonly IGenericRepositoryAsync<GLIncomeRegister> _glIncomeRegisterRepository;
        private readonly IGenericRepositoryAsync<SupplyRegister> _supplyRegisterRepository;
        private readonly IGenericRepositoryAsync<EInvoiceRegister> _einvoiceRegisterRepository;
        private readonly IGenericRepositoryAsync<EWayBillRegister> _ewaybillRegisterRepository;
        private readonly IGenericRepositoryAsync<LiabilityLedger> _liabilityLedgerRepository;
        private readonly IGenericRepositoryAsync<AdvanceReceived> _advanceReceivedRepository;
        private readonly IGenericRepositoryAsync<FinalOutputRegister> _finalOutoutRepository;
        private readonly IDocumentTypeRepositoryAsync _documentTypeRepository;
        private readonly IMapper _mapper;

        public DocumentTypeService(IGenericRepositoryAsync<DocumentType> documentTypeRepositoryAsync, 
            IGenericRepositoryAsync<GLIncomeRegister> glIncomeRegisterRepository, 
            IGenericRepositoryAsync<SupplyRegister> supplyRegisterRepository, 
            IGenericRepositoryAsync<EInvoiceRegister> einvoiceRegisterRepository, 
            IGenericRepositoryAsync<EWayBillRegister> ewaybillRegisterRepository, 
            IGenericRepositoryAsync<LiabilityLedger> liabilityLedgerRepository, 
            IGenericRepositoryAsync<AdvanceReceived> advanceReceivedRepository,  
            IGenericRepositoryAsync<FinalOutputRegister> finalOutoutRepository,
            IDocumentTypeRepositoryAsync documentTypeRepository, 
            IMapper mapper)
        {
            _documentTypeRepositoryAsync = documentTypeRepositoryAsync;
            _glIncomeRegisterRepository = glIncomeRegisterRepository;
            _supplyRegisterRepository = supplyRegisterRepository;
            _einvoiceRegisterRepository = einvoiceRegisterRepository;
            _ewaybillRegisterRepository = ewaybillRegisterRepository;
            _liabilityLedgerRepository = liabilityLedgerRepository;
            _advanceReceivedRepository = advanceReceivedRepository;
            _documentTypeRepository = documentTypeRepository;
            _finalOutoutRepository = finalOutoutRepository;
            _mapper = mapper;
        }

        public async Task<DocumentTypeViewModel> AddDocumentType(CreateDocumentTypeCommand command)
        {

            var applicationDocumentType = _mapper.Map<DocumentType>(command);
            applicationDocumentType.CreatedOn = DateTime.Now;
            applicationDocumentType.IsActive = IsActive.Active;
            await _documentTypeRepositoryAsync.AddAsync(applicationDocumentType);

            return _mapper.Map<DocumentTypeViewModel>(applicationDocumentType);
        }

        public async Task DeleteDocumentType(DeleteDocumentTypeCommand command)
        {
            if (command.Id > 0)
            {
                var applicationDocumentType = await _documentTypeRepositoryAsync.FindById(command.Id);
                applicationDocumentType.IsActive = IsActive.Delete;
                await _documentTypeRepositoryAsync.UpdateAsync(applicationDocumentType);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<DocumentTypeViewModel> EditDocumentType(UpdateDocumentTypeCommand command)
        {
            var applicationDocumentType = _mapper.Map<UpdateDocumentTypeCommand>(command);
            applicationDocumentType.IsActive = IsActive.Active;
            applicationDocumentType.ModifiedOn = DateTime.Now;
            var applicationUser = await _documentTypeRepositoryAsync.FindById(applicationDocumentType.Id);
            _mapper.Map(command, applicationUser);

            await _documentTypeRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<DocumentTypeViewModel>(applicationUser);
        }

        public async Task<DocumentTypeViewModel> GetDocumentTypeById(long id)
        {
            var applicationDocumentType = await _documentTypeRepositoryAsync.FindById(id);
            return _mapper.Map<DocumentTypeViewModel>(applicationDocumentType);
        }

        public async Task<IEnumerable<DocumentTypeListModel>> GetDocumentTypeList()
        {
            var documentTypeList = await _documentTypeRepositoryAsync.GetAllAsync();
            //documentTypeList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<DocumentTypeViewModel>>(documentTypeList).Where(x => x.IsActive != IsActive.Delete);

            var documentTypes = documentTypeList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new DocumentTypeListModel()
                {
                    Id = y.Id,
                    BillType = y.BillType,
                    Document_Code = y.Document_Code,
                    Document_Type = y.Document_Type,
                    OurSoftwareProcessing = y.OurSoftwareProcessing,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return documentTypes;

        }

        public async Task<object> GetPreViewDocumentList(string month, string year, string type)
        {
            //case GLGR            
            //_repo
            //return 
            //case 2
            //_repo
            //return

            string Type = type;
            switch (Type)
            {
                case "GLINR":
                    //var gldocumentTypeList = await _glIncomeRegisterRepository.GetAllByCondition(x => x.Month == month && x.Year == year).ToListAsync();
                    var gldocumentTypeList = await _documentTypeRepository.GetGLDocumentPrivew(month,year);
                    return gldocumentTypeList;
                case "SUPR":
                    //var sldocumentTypeList = await _supplyRegisterRepository.GetAllByCondition(x => x.Month == month && x.Year == year).ToListAsync();
                    var sldocumentTypeList = await _documentTypeRepository.GetSLDocumentPrivew(month, year);
                    return sldocumentTypeList;
                case "EINR":
                    //var eindocumentTypeList = await _einvoiceRegisterRepository.GetAllByCondition(x => x.Month == month && x.Year == year).ToListAsync();
                    var eindocumentTypeList = await _documentTypeRepository.GetEInvoiceDocumentPrivew(month, year);
                    return eindocumentTypeList;
                case "EWBILR":
                    //var ewbdocumentTypeList = await _ewaybillRegisterRepository.GetAllByCondition(x => x.Month == month && x.Year == year).ToListAsync();
                    var ewbdocumentTypeList = await _documentTypeRepository.GetEWayBillDocumentPrivew(month, year);
                    return ewbdocumentTypeList;
                case "LIBLGR":
                    //var libdocumentTypeList = await _liabilityLedgerRepository.GetAllByCondition(x => x.Month == month && x.Year == year).ToListAsync();
                    var libdocumentTypeList = await _documentTypeRepository.GetLLDocumentPrivew(month, year);
                        return libdocumentTypeList;               
                case "ADVREC":
                    //var advrecdocumentTypeList = await _advanceReceivedRepository.GetAllByCondition(x => x.Month == month && x.Year == year).ToListAsync();
                    var advrecdocumentTypeList = await _documentTypeRepository.GetAdvRecDocumentPrivew(month, year);
                    return advrecdocumentTypeList;
                case "FOUTPUT":
                    //var libdocumentTypeList = await _liabilityLedgerRepository.GetAllByCondition(x => x.Month == month && x.Year == year).ToListAsync();
                    var foutputdocumentTypeData = await _documentTypeRepository.GetFOPDocumentPreview(month, year);
                    return foutputdocumentTypeData;

                default:
                    return null;
            }        

        }

        public async Task<long> GetDocumentData(string month, string year, string type)
        {
            string Type = type;
            switch (Type)
            {
                case "GLINR":
                    var gldocumentData = _glIncomeRegisterRepository.GetAllByCondition(x => x.Month == month && x.Year == year);
                    return await gldocumentData.CountAsync();
                case "SUPR":
                    var sldocumentTypeData = _supplyRegisterRepository.GetAllByCondition(x => x.Month == month && x.Year == year);
                    return await sldocumentTypeData.CountAsync();
                case "EINR":
                    var eindocumentTypeData =  _einvoiceRegisterRepository.GetAllByCondition(x => x.Month == month && x.Year == year);
                    return await eindocumentTypeData.CountAsync();
                case "EWBILR":
                    var ewbdocumentTypeData =  _ewaybillRegisterRepository.GetAllByCondition(x => x.Month == month && x.Year == year);
                    return await ewbdocumentTypeData.CountAsync();
                case "LIBLGR":
                    var libdocumentTypeData =  _liabilityLedgerRepository.GetAllByCondition(x => x.Month == month && x.Year == year);
                    return await libdocumentTypeData.CountAsync();
                case "ADVREC":
                    var advrecdocumentTypeData = _advanceReceivedRepository.GetAllByCondition(x => x.Month == month && x.Year == year);
                    return await advrecdocumentTypeData.CountAsync();
                case "FOUTPUT":
                    var foutputdocumentTypeData = _finalOutoutRepository.GetAllByCondition(x => x.Month == month && x.Year == year);
                    return await foutputdocumentTypeData.CountAsync();
                default:
                    return 0;
            }
            
        }

        public async Task DeleteData(DeleteDataCommand command)
        {
            if (command.Month != "" && command.Year != "")
            {
                string Type = command.Type;
                switch (Type)
                {
                    case "GLINR":
                        var applicationDocumentType = await _glIncomeRegisterRepository.GetAllByCondition(x => x.Month == command.Month && x.Year == command.Year).ToListAsync();
                        await _glIncomeRegisterRepository.DeleteManyAsync(applicationDocumentType);
                        break;
                    case "SUPR":
                        var sldocumentTypeList = await _supplyRegisterRepository.GetAllByCondition(x => x.Month == command.Month && x.Year == command.Year).ToListAsync();
                        await _supplyRegisterRepository.DeleteManyAsync(sldocumentTypeList);
                        break;
                    case "EINR":
                        var eindocumentType = await _einvoiceRegisterRepository.GetAllByCondition(x => x.Month == command.Month && x.Year == command.Year).ToListAsync();
                        await _einvoiceRegisterRepository.DeleteManyAsync(eindocumentType);
                        break;
                    case "EWBILR":
                        var ewbdocumentType = await _ewaybillRegisterRepository.GetAllByCondition(x => x.Month == command.Month && x.Year == command.Year).ToListAsync();
                        await _ewaybillRegisterRepository.DeleteManyAsync(ewbdocumentType);
                        break;
                    case "LIBLGR":
                        var libdocumentType = await _liabilityLedgerRepository.GetAllByCondition(x => x.Month == command.Month && x.Year == command.Year).ToListAsync();
                        await _liabilityLedgerRepository.DeleteManyAsync(libdocumentType);
                        break;
                    case "ADVREC":
                        var advrecdocumentType = await _advanceReceivedRepository.GetAllByCondition(x => x.Month == command.Month && x.Year == command.Year).ToListAsync();
                        await _advanceReceivedRepository.DeleteManyAsync(advrecdocumentType);
                        break;
                    case "FOUTPUT":
                        var foutputdocumentTypeData = await _finalOutoutRepository.GetAllByCondition(x => x.Month == command.Month && x.Year == command.Year).ToListAsync();
                        await _finalOutoutRepository.DeleteManyAsync(foutputdocumentTypeData);
                        break;

                    default:
                        return;
                }

                //var applicationDocumentType = await _glIncomeRegisterRepository.GetAllByCondition(x => x.Month == command.Month && x.Year == command.Year && x.Type == command.Type).ToListAsync();
                //await _glIncomeRegisterRepository.DeleteManyAsync(applicationDocumentType);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<bool> UpdateInvoiceAmendmentData(List<InvoiceAmendmentUpdateViewModel> invoiceAmendmentUpdateList)
        {
            var isSuccessfull = await _documentTypeRepository.UpdateInvoiceAmendmentData(invoiceAmendmentUpdateList);
            return isSuccessfull;
        }
    }
}