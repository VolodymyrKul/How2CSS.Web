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
    public class HintService : BaseService, IHintService
    {
        public HintService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(HintDTO entity)
        {
            var value = new Hint();
            _mapper.Map(entity, value);
            await _unitOfWork.HintRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.HintRepo.GetByIdAsync(id);
            await _unitOfWork.HintRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<HintDTO>> GetAll()
        {
            var hints = await _unitOfWork.HintRepo.GetAllAsync();
            List<HintDTO> hintDTOs = hints.Select(hint => _mapper.Map(hint, new HintDTO())).ToList();
            return hintDTOs;
        }

        public virtual async Task<HintDTO> GetIdAsync(int id)
        {
            var hint = await _unitOfWork.HintRepo.GetByIdAsync(id);
            if (hint == null)
                throw new Exception("Such order not found");
            var dto = new HintDTO();
            _mapper.Map(hint, dto);
            return dto;
        }

        public virtual async Task<HintDTO> UpdateAsync(HintDTO entity)
        {
            var value = new Hint();
            _mapper.Map(entity, value);
            await _unitOfWork.HintRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
