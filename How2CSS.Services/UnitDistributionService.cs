using AutoMapper;
using How2CSS.Core.Abstractions;
using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
using How2CSS.Core.Models;
using How2CSS.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Services
{
    public class UnitDistributionService : BaseService, IUnitDistributionService
    {
        public UnitDistributionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(UnitDistributionDTO entity)
        {
            var value = new UnitDistribution();
            _mapper.Map(entity, value);
            await _unitOfWork.UnitDistributionRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.UnitDistributionRepo.GetByIdAsync(id);
            await _unitOfWork.UnitDistributionRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<UnitDistributionDTO>> GetAll()
        {
            var unitDistributions = await _unitOfWork.UnitDistributionRepo.GetAllAsync();
            List<UnitDistributionDTO> unitDistributionDTOs = unitDistributions.Select(unitDistribution => _mapper.Map(unitDistribution, new UnitDistributionDTO())).ToList();
            return unitDistributionDTOs;
        }

        public virtual async Task<UnitDistributionDTO> GetIdAsync(int id)
        {
            var unitDistribution = await _unitOfWork.UnitDistributionRepo.GetByIdAsync(id);
            if (unitDistribution == null)
                throw new Exception("Such order not found");
            var dto = new UnitDistributionDTO();
            _mapper.Map(unitDistribution, dto);
            return dto;
        }

        public virtual async Task<UnitDistributionDTO> UpdateAsync(UnitDistributionDTO entity)
        {
            var value = new UnitDistribution();
            _mapper.Map(entity, value);
            await _unitOfWork.UnitDistributionRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
