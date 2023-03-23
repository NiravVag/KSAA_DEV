using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand;
using KSAA.Master.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Shared.Services
{
    public class TBTaggingService : ITBTaggingService
    {
        private readonly IGenericRepositoryAsync<TBTagging> _TBTaggingRepositoryAsync;
        private readonly IMapper _mapper;

        public TBTaggingService(IGenericRepositoryAsync<TBTagging> TBTaggingRepositoryAsync, IMapper mapper)
        {
            _TBTaggingRepositoryAsync = TBTaggingRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<TBTaggingViewModel> AddTBTagging(CreateTBTaggingCommand command)
        {
            var applicationTBTagging = _mapper.Map<TBTagging>(command);
            applicationTBTagging.CreatedOn = DateTime.Now;
            applicationTBTagging.IsActive = IsActive.Active;
            await _TBTaggingRepositoryAsync.AddAsync(applicationTBTagging);

            return _mapper.Map<TBTaggingViewModel>(applicationTBTagging);
        }

        public async Task DeleteTBTagging(DeleteTBTaggingCommand command)
        {
            if (command.Id > 0)
            {
                var applicationTBTagging = await _TBTaggingRepositoryAsync.FindById(command.Id);
                applicationTBTagging.IsActive = IsActive.Delete;
                await _TBTaggingRepositoryAsync.UpdateAsync(applicationTBTagging);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<TBTaggingViewModel> EditTBTagging(UpdateTBTaggingCommand command)
        {
            var applicationTBTagging = _mapper.Map<UpdateTBTaggingCommand>(command);
            applicationTBTagging.IsActive = IsActive.Active;
            applicationTBTagging.ModifiedOn = DateTime.Now;
            var applicationUser = await _TBTaggingRepositoryAsync.FindById(applicationTBTagging.Id);
            _mapper.Map(command, applicationUser);

            await _TBTaggingRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<TBTaggingViewModel>(applicationUser);
        }

        public async Task<TBTaggingViewModel> GetTBTaggingById(long id)
        {
            var applicationTBTagging = await _TBTaggingRepositoryAsync.FindById(id);
            return _mapper.Map<TBTaggingViewModel>(applicationTBTagging);
        }

        public async Task<IEnumerable<TBTaggingListModel>> GetTBTaggingList()
        {
            var TBTaggingList = await _TBTaggingRepositoryAsync.GetAllAsync();
            //TBTaggingList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<TBTaggingViewModel>>(TBTaggingList).Where(x => x.IsActive != IsActive.Delete);

            var tbTaggings = TBTaggingList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new TBTaggingListModel()
                {
                    Id = y.Id,
                    TBTaggingCode = y.TBTaggingCode,
                    GLCode = y.GLCode,
                    GLName = y.GLName,
                    Amount = y.Amount,
                    TagCode = y.TagCode,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return tbTaggings;

        }
    }
}