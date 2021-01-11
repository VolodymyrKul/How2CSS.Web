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
    public class UnitService : BaseService, IUnitService
    {
        public UnitService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(UnitDTO entity)
        {
            var value = new Unit();
            _mapper.Map(entity, value);
            await _unitOfWork.UnitRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.UnitRepo.GetByIdAsync(id);
            await _unitOfWork.UnitRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<UnitDTO>> GetAll()
        {
            var units = await _unitOfWork.UnitRepo.GetAllAsync();
            List<UnitDTO> unitDTOs = units.Select(unit => _mapper.Map(unit, new UnitDTO())).ToList();
            return unitDTOs;
        }

        public virtual async Task<UnitDTO> GetIdAsync(int id)
        {
            var unit = await _unitOfWork.UnitRepo.GetByIdAsync(id);
            if (unit == null)
                throw new Exception("Such order not found");
            var dto = new UnitDTO();
            _mapper.Map(unit, dto);
            return dto;
        }

        public virtual async Task<UnitDTO> UpdateAsync(UnitDTO entity)
        {
            var value = new Unit();
            _mapper.Map(entity, value);
            await _unitOfWork.UnitRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
