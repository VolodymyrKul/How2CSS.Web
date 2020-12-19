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
    public class AchievementDataService : BaseService, IAchievementDataService
    {
        public AchievementDataService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(AchievementDataDTO entity)
        {
            var value = new AchievementData();
            _mapper.Map(entity, value);
            await _unitOfWork.AchievementDataRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.AchievementDataRepo.GetByIdAsync(id);
            await _unitOfWork.AchievementDataRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<AchievementDataDTO>> GetAll()
        {
            var achievementDatas = await _unitOfWork.AchievementDataRepo.GetAllAsync();
            List<AchievementDataDTO> achievementDataDTOs = achievementDatas.Select(achievementData => _mapper.Map(achievementData, new AchievementDataDTO())).ToList();
            return achievementDataDTOs;
        }

        public virtual async Task<AchievementDataDTO> GetIdAsync(int id)
        {
            var achievementData = await _unitOfWork.AchievementDataRepo.GetByIdAsync(id);
            if (achievementData == null)
                throw new Exception("Such order not found");
            var dto = new AchievementDataDTO();
            _mapper.Map(achievementData, dto);
            return dto;
        }

        public virtual async Task<AchievementDataDTO> UpdateAsync(AchievementDataDTO entity)
        {
            var value = new AchievementData();
            _mapper.Map(entity, value);
            await _unitOfWork.AchievementDataRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
