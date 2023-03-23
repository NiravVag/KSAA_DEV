using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.LocationCommand;
using KSAA.Master.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Shared.Services
{
    public class LocationService : ILocationService
    {
        private readonly IGenericRepositoryAsync<Location> _LocationRepositoryAsync;
        private readonly IMapper _mapper;

        public LocationService(IGenericRepositoryAsync<Location> LocationRepositoryAsync, IMapper mapper)
        {
            _LocationRepositoryAsync = LocationRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<LocationViewModel> AddLocation(CreateLocationCommand command)
        {
            var applicationLocation = _mapper.Map<Location>(command);
            applicationLocation.CreatedOn = DateTime.Now;
            applicationLocation.IsActive = IsActive.Active;
            await _LocationRepositoryAsync.AddAsync(applicationLocation);

            return _mapper.Map<LocationViewModel>(applicationLocation);
        }

        public async Task DeleteLocation(DeleteLocationCommand command)
        {
            if (command.Id > 0)
            {
                var applicationLocation = await _LocationRepositoryAsync.FindById(command.Id);
                applicationLocation.IsActive = IsActive.Delete;
                await _LocationRepositoryAsync.UpdateAsync(applicationLocation);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<LocationViewModel> EditLocation(UpdateLocationCommand command)
        {
            var applicationLocation = _mapper.Map<UpdateLocationCommand>(command);
            applicationLocation.IsActive = IsActive.Active;
            applicationLocation.ModifiedOn = DateTime.Now;
            var applicationUser = await _LocationRepositoryAsync.FindById(applicationLocation.Id);
            _mapper.Map(command, applicationUser);

            await _LocationRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<LocationViewModel>(applicationUser);
        }

        public async Task<LocationViewModel> GetLocationById(long id)
        {
            var applicationLocation = await _LocationRepositoryAsync.FindById(id);
            return _mapper.Map<LocationViewModel>(applicationLocation);
        }

        public async Task<IEnumerable<LocationListModel>> GetLocationList()
        {
            var LocationList = await _LocationRepositoryAsync.GetAllAsync();
            //LocationList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<LocationViewModel>>(LocationList).Where(x => x.IsActive != IsActive.Delete);

            var locations = LocationList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new LocationListModel()
                {
                    Id = y.Id,
                    Location_Code = y.Location_Code,
                    Address = y.Address,
                    GSTRegistrationNo = y.GSTRegistrationNo,
                    TypeOfUnit = y.TypeOfUnit,
                    ProductsManufactured = y.ProductsManufactured,
                    ProductsTraded = y.ProductsTraded,
                    TypeOfServicesProvided = y.TypeOfServicesProvided,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return locations;

        }
    }
}