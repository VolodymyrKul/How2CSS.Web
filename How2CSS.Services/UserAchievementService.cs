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
    public class UserAchievementService : BaseService, IUserAchievementService
    {
        public UserAchievementService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(UserAchievementDTO entity)
        {
            var value = new UserAchievement();
            _mapper.Map(entity, value);
            await _unitOfWork.UserAchievementRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.UserAchievementRepo.GetByIdAsync(id);
            await _unitOfWork.UserAchievementRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<UserAchievementDTO>> GetAll()
        {
            var userAchievements = await _unitOfWork.UserAchievementRepo.GetAllAsync();
            List<UserAchievementDTO> userAchievementDTOs = userAchievements.Select(userAchievement => _mapper.Map(userAchievement, new UserAchievementDTO())).ToList();
            return userAchievementDTOs;
        }

        public virtual async Task<UserAchievementDTO> GetIdAsync(int id)
        {
            var userAchievement = await _unitOfWork.UserAchievementRepo.GetByIdAsync(id);
            if (userAchievement == null)
                throw new Exception("Such order not found");
            var dto = new UserAchievementDTO();
            _mapper.Map(userAchievement, dto);
            return dto;
        }

        public virtual async Task<UserAchievementDTO> UpdateAsync(UserAchievementDTO entity)
        {
            var value = new UserAchievement();
            _mapper.Map(entity, value);
            await _unitOfWork.UserAchievementRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
