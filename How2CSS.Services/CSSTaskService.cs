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
    public class CSSTaskService : BaseService, ICSSTaskService
    {
        public CSSTaskService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(CSSTaskDTO entity)
        {
            var value = new CSSTask();
            _mapper.Map(entity, value);
            await _unitOfWork.CSSTaskRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CSSTaskRepo.GetByIdAsync(id);
            await _unitOfWork.CSSTaskRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<CSSTaskDTO>> GetAll()
        {
            var cSSTasks = await _unitOfWork.CSSTaskRepo.GetAllAsync();
            List<CSSTaskDTO> cSSTaskDTOs = cSSTasks.Select(cSSTask => _mapper.Map(cSSTask, new CSSTaskDTO())).ToList();
            return cSSTaskDTOs;
        }

        public virtual async Task<CSSTaskDTO> GetIdAsync(int id)
        {
            var cSSTask = await _unitOfWork.CSSTaskRepo.GetByIdAsync(id);
            if (cSSTask == null)
                throw new Exception("Such order not found");
            var dto = new CSSTaskDTO();
            _mapper.Map(cSSTask, dto);
            return dto;
        }

        public virtual async Task<CSSTaskDTO> UpdateAsync(CSSTaskDTO entity)
        {
            var value = new CSSTask();
            _mapper.Map(entity, value);
            await _unitOfWork.CSSTaskRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
