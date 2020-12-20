using AutoMapper;
using How2CSS.Core.Abstractions;
using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using How2CSS.Core.Models;
using How2CSS.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Services
{
    public class LevelService : BaseService, ILevelService
    {
        public LevelService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(LevelDTO entity)
        {
            var value = new Level();
            _mapper.Map(entity, value);
            await _unitOfWork.LevelRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.LevelRepo.GetByIdAsync(id);
            await _unitOfWork.LevelRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<LevelDTO>> GetAll()
        {
            var levels = await _unitOfWork.LevelRepo.GetAllAsync();
            List<LevelDTO> levelDTOs = levels.Select(level => _mapper.Map(level, new LevelDTO())).ToList();
            return levelDTOs;
        }

        public virtual async Task<LevelDTO> GetIdAsync(int id)
        {
            var level = await _unitOfWork.LevelRepo.GetByIdAsync(id);
            if (level == null)
                throw new Exception("Such order not found");
            var dto = new LevelDTO();
            _mapper.Map(level, dto);
            return dto;
        }

        public virtual async Task<LevelDTO> UpdateAsync(LevelDTO entity)
        {
            var value = new Level();
            _mapper.Map(entity, value);
            await _unitOfWork.LevelRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
