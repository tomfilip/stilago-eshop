using Stilago.Fundamentals.Interface;
using Stilago.Models;
using Stilago.Repository;
using Stilago.Services.Interface;
using Stilago.ViewModels.Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Services
{
    public class ComputerService: StilagoAppServiceBase, IComputerService
    {
        public ComputerService(
            IComputerRepository computerRepository, 
            IUserInfo userInfo,
            IComputerInfoRepository computerInfoRepository,
            IBrandRepository brandRepository,
            IBrandComputerRelationshipRepository brandComputerRelationshipRepository)
        {
            _ComputerRepository = computerRepository;
            _UserInfo = userInfo;
            _ComputerInfoRepository = computerInfoRepository;
            _BrandRepository = brandRepository;
            _BrandComputerRelationshipRepository = brandComputerRelationshipRepository;
        }

        IBrandRepository _BrandRepository;
        IBrandComputerRelationshipRepository _BrandComputerRelationshipRepository;
        IComputerInfoRepository _ComputerInfoRepository;
        IComputerRepository _ComputerRepository;
        IUserInfo _UserInfo;

        public GetOutput Get(GetInput input)
        {
            var currentCountry = _UserInfo.GetCurrentCountry();

            if (input.Id.HasValue)
            {
                var vm = _ComputerRepository.GetAll().Where(x => x.Id == input.Id.Value
                                && x.IsDeleted == false).Select( x => new ViewModels.Computer.CreateEditViewModel(){
                                    BrandName = x.CountryBrandRelationships.FirstOrDefault(y => y.Brand.CountryId == currentCountry.Id).Brand.Name,
                                    Description = x.ComputerInfo.FirstOrDefault(y => y.CountryId == currentCountry.Id).Description,
                                    DiskCapacity = x.DiskCapacity,
                                    Id = x.Id,
                                    Model = x.Model,
                                    Price = x.ComputerInfo.FirstOrDefault(y => y.CountryId == currentCountry.Id).Price
                                }).First();

                return new GetOutput
                {
                    Computer = vm
                };
            }
            else
            {
                return new GetOutput
                {
                    Computer = new CreateEditViewModel()
                };
            }
            
        }

        public CreateEditOutput Create(CreateEditInput input)
        {
            var currentUser = _UserInfo.GetCurrentUser();

            //Map the properties from the view model
            Computer newItem = AutoMapper.Mapper.Map<Computer>(input.Computer);

            //Make sure to reset the id to a new Id
            newItem.Id = Guid.NewGuid();
            //Set the audit properties
            newItem.CreatedById = currentUser.Id;
            newItem.CreationTime = DateTimeOffset.Now;
            newItem.ModifiedById = currentUser.Id;
            newItem.LastModificationTime = DateTimeOffset.Now;

            //Check if there is already such a brand name in the local country
            Brand brand = _BrandRepository.GetAll().FirstOrDefault(x => x.Name == input.Computer.BrandName && x.CountryId == currentUser.CountryId);

            //If the local country brand does not exist create one
            if (brand == null)
            {
                brand = new Brand();
                brand.Id = Guid.NewGuid();
                brand.Name = input.Computer.BrandName;
                brand.CountryId = currentUser.CountryId;
                //Audit
                brand.CreatedById = currentUser.Id;
                brand.CreationTime = DateTimeOffset.Now;
                brand.ModifiedById = currentUser.Id;
                brand.LastModificationTime = DateTimeOffset.Now;

                _BrandRepository.Insert(brand);
            }
            
            //because the computer is new just insert a relationship
            BrandComputerRelationship rel = new BrandComputerRelationship();
            rel.Id = Guid.NewGuid();
            rel.BrandId = brand.Id;
            rel.ComputerId = newItem.Id;

            _BrandComputerRelationshipRepository.Insert(rel);

            ComputerInfo info = new ComputerInfo();
            info.Id = Guid.NewGuid();
            info.Price = input.Computer.Price;
            info.Description = input.Computer.Description;
            info.CountryId = currentUser.CountryId;
            info.ComputerId = newItem.Id;
            //Audit
            info.CreatedById = currentUser.Id;
            info.CreationTime = DateTime.Now;
            info.ModifiedById = currentUser.Id;
            info.LastModificationTime = DateTime.Now;

            _ComputerRepository.Insert(newItem);
            _ComputerInfoRepository.Insert(info);

            return new CreateEditOutput()
            { 
                Id = newItem.Id
            };
        }

        public CreateEditOutput Update(CreateEditInput input)
        {
            var currentUser = _UserInfo.GetCurrentUser();
            
            Computer existingItem = _ComputerRepository.GetAll().First(x => x.Id == input.Computer.Id);
            if (existingItem.CreatedById != currentUser.Id)
            { throw new UnauthorizedAccessException("You can update only the items you have created"); }

            existingItem.DiskCapacity = input.Computer.DiskCapacity;
            existingItem.Model = input.Computer.Model;
            //Set the audit properties
            existingItem.ModifiedById = currentUser.Id;
            existingItem.LastModificationTime = DateTimeOffset.Now;

            //We want to reuse the brands and don't want to create duplicates for the local country. Therefore we check it by the name
            Brand brand = _BrandRepository.GetAll().FirstOrDefault(x => x.Name == input.Computer.BrandName && x.CountryId == currentUser.CountryId);

            //If the local country brand does not exist create one
            if (brand == null)
            {
                brand = new Brand();
                brand.Id = Guid.NewGuid();
                brand.Name = input.Computer.BrandName;
                brand.CountryId = currentUser.CountryId;
                //Audit
                brand.CreatedById = currentUser.Id;
                brand.CreationTime = DateTimeOffset.Now;
                brand.ModifiedById = currentUser.Id;
                brand.LastModificationTime = DateTimeOffset.Now;

                _BrandRepository.Insert(brand);
            }

            //Now delete all the existing relationships for this computer and this country
            //If there has been no bug in the code there should be only one
            var brandRelationshipsToDelete = _BrandComputerRelationshipRepository.GetAll().Where(x => x.ComputerId == existingItem.Id && x.Brand.CountryId == currentUser.CountryId).ToList();
            foreach(var rel in brandRelationshipsToDelete)
            {
                _BrandComputerRelationshipRepository.Delete(rel);
            }

            //Now insert a new relationship
            BrandComputerRelationship newRelationship = new BrandComputerRelationship();
            newRelationship.BrandId = brand.Id;
            newRelationship.ComputerId = existingItem.Id;
            newRelationship.Id = Guid.NewGuid();

            _BrandComputerRelationshipRepository.Insert(newRelationship);

            ComputerInfo info = _ComputerInfoRepository.GetAll().FirstOrDefault(x => x.ComputerId == existingItem.Id && x.CountryId == currentUser.CountryId);
            //If the local country computer info does not exist. Create it
            if (info == null)
            {
                info = new ComputerInfo();
                info.Id = Guid.NewGuid();
                info.Price = input.Computer.Price;
                info.Description = input.Computer.Description;
                info.CountryId = currentUser.CountryId;
                info.ComputerId = existingItem.Id;
                //Audit
                info.CreatedById = currentUser.Id;
                info.CreationTime = DateTimeOffset.Now;
                info.ModifiedById = currentUser.Id;
                info.LastModificationTime = DateTimeOffset.Now;

                _ComputerInfoRepository.Insert(info);
            }
            //If the local country computer info exists update it
            else
            {
                info.Price = input.Computer.Price;
                info.Description = input.Computer.Description;
                //Audit
                info.ModifiedById = currentUser.Id;
                info.LastModificationTime = DateTimeOffset.Now;

                _ComputerInfoRepository.Update(info);
            }

            _ComputerRepository.Update(existingItem);

            return new CreateEditOutput()
            {
                Id = existingItem.Id
            };
        }

        public void Delete(DeleteInput input)
        {
            var currentUser = _UserInfo.GetCurrentUser();

            var computer = _ComputerRepository.GetAll().First(x => x.Id == input.Id);

            if (computer.CreatedById != currentUser.Id)
            { throw new UnauthorizedAccessException("You are not the creator of this item. So you can't delete it"); }

            computer.IsDeleted = true;

            _ComputerRepository.Update(computer);
        }
    }
}
