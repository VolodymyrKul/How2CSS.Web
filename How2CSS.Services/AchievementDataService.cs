using AutoMapper;
using How2CSS.Core.Abstractions;
using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs;
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

        public virtual async Task<List<CompareAchievDataDTO>> GetCompareAchievs(string OwnUserEmail, string AnotherUserEmail)
        {
            var users = await _unitOfWork.UserRepo.GetAllAsync();
            int OwnUserId = users.FirstOrDefault(u => u.Email == OwnUserEmail).Id;
            int AnotherUserId = users.FirstOrDefault(u => u.Email == AnotherUserEmail).Id;
            List<UserAchievement> allUserAchievements = (await _unitOfWork.UserAchievementRepo.GetAllAsync()).ToList();
            List<UserAchievement> ownAchievs = allUserAchievements.Where(ua => ua.IdUser == OwnUserId).ToList();
            List<UserAchievement> antAchievs = allUserAchievements.Where(ua => ua.IdUser == AnotherUserId).ToList();
            List<int> antAchievIds = new List<int>();

            List<AchievementData> ownAchievementDatas = new List<AchievementData>();
            List<AchievementData> antAchievementDatas = new List<AchievementData>();
            List<AchievementData> allAchievementDatas = (await _unitOfWork.AchievementDataRepo.GetAllAsync()).ToList();
            List<int> findAbsentArr = new List<int>();
            for(int i=0; i < ownAchievs.Count; i++)
            {
                UserAchievement result = null;
                result = antAchievs.FirstOrDefault(ua => ua.IdLevel == ownAchievs[i].IdLevel);
                if (result == null)
                {
                    findAbsentArr.Add(i);
                }
                else
                {
                    antAchievIds.Add(result.Id);
                }
            }

            foreach (int findAbsent in findAbsentArr)
            {
                ownAchievs.RemoveAt(findAbsent);
            }

            foreach(UserAchievement ownAchiev in ownAchievs)
            {
                ownAchievementDatas.AddRange(allAchievementDatas.Where(ad => ad.IdUserAchievement == ownAchiev.Id));
            }

            foreach (int antAchievId in antAchievIds)
            {
                antAchievementDatas.AddRange(allAchievementDatas.Where(ad => ad.IdUserAchievement == antAchievId));
            }

            List<CompareAchievDataDTO> compareAchievDataDTOs = new List<CompareAchievDataDTO>();
            for(int j = 0; j < ownAchievs.Count; j++)
            {
                Level CurrentLevel = await _unitOfWork.LevelRepo.GetByIdAsync(ownAchievs[j].IdLevel);
                string LevelTitle = CurrentLevel.Title;
                int LevelTotal = CurrentLevel.TasksCount;
                int CompareTryCount = 0;
                int OwnCount = ownAchievementDatas.Count(ad => ad.IdUserAchievement == ownAchievs[j].Id);
                int AntCount = antAchievementDatas.Count(ad => ad.IdUserAchievement == antAchievIds[j]);
                if (OwnCount >= AntCount)
                {
                    CompareTryCount = OwnCount;
                }
                else
                {
                    CompareTryCount = AntCount;
                }

                for(int k = 0; k < CompareTryCount; k++)
                {
                    CompareAchievDataDTO compareAchievDataDTO = new CompareAchievDataDTO();
                    AchievementData ownAchievementData = ownAchievementDatas.FirstOrDefault(ad => ad.IdUserAchievement == ownAchievs[j].Id && ad.TryCount == k + 1);
                    AchievementData antAchievementData = antAchievementDatas.FirstOrDefault(ad => ad.IdUserAchievement == antAchievIds[j] && ad.TryCount == k + 1);
                    if(ownAchievementData == null)
                    {
                        compareAchievDataDTO.OwnCompletedCount = "-";
                        compareAchievDataDTO.OwnCorrectCount = "-";
                        compareAchievDataDTO.OwnCurrentMark = "-";
                    }
                    else
                    {
                        compareAchievDataDTO.OwnCompletedCount = ownAchievementData.CompletedCount.ToString() + "/" + LevelTotal.ToString();
                        compareAchievDataDTO.OwnCorrectCount = ownAchievementData.CorrectCount.ToString() + "/" + LevelTotal.ToString();
                        compareAchievDataDTO.OwnCurrentMark = ownAchievementData.CurrentMark.ToString();
                    }

                    if (antAchievementData == null)
                    {
                        compareAchievDataDTO.AntCompletedCount = "-";
                        compareAchievDataDTO.AntCorrectCount = "-";
                        compareAchievDataDTO.AntCurrentMark = "-";
                    }
                    else
                    {
                        compareAchievDataDTO.AntCompletedCount = antAchievementData.CompletedCount.ToString() + "/" + LevelTotal.ToString();
                        compareAchievDataDTO.AntCorrectCount = antAchievementData.CorrectCount.ToString() + "/" + LevelTotal.ToString();
                        compareAchievDataDTO.AntCurrentMark = antAchievementData.CurrentMark.ToString();
                    }
                    compareAchievDataDTO.TrainingTestTitle = LevelTitle;
                    compareAchievDataDTOs.Add(compareAchievDataDTO);
                }
            }
            return compareAchievDataDTOs;
        }

        public virtual async Task<List<SimpleAchievDataDTO>> GetAchievsByEmail(string UserEmail)
        {
            List<UserAchievement> userAchievements = (await _unitOfWork.UserAchievementRepo.GetAllAsync()).Where(ua => ua.IdUserNavigation.Email == UserEmail).ToList();
            List<AchievementData> achievementDatas = new List<AchievementData>();
            List<AchievementData> allAchievementDatas = (await _unitOfWork.AchievementDataRepo.GetAllAsync()).ToList();
            foreach (UserAchievement userAchievement in userAchievements)
            {
                achievementDatas.AddRange(allAchievementDatas.Where(ad => ad.IdUserAchievement == userAchievement.Id));
            }
            List<SimpleAchievDataDTO> simpleAchievDataDTOs = achievementDatas.Select(ad => _mapper.Map(ad, new SimpleAchievDataDTO())).ToList();
            return simpleAchievDataDTOs;
        }

        public virtual async Task<List<DetailAchievDataDTO>> GetDetailAchievsByEmail(string UserEmail)
        {
            List<UserAchievement> userAchievements = (await _unitOfWork.UserAchievementRepo.GetAllAsync()).Where(ua => ua.IdUserNavigation.Email == UserEmail).ToList();
            List<AchievementData> achievementDatas = new List<AchievementData>();
            List<AchievementData> allAchievementDatas = (await _unitOfWork.AchievementDataRepo.GetAllAsync()).ToList();
            foreach (UserAchievement userAchievement in userAchievements)
            {
                achievementDatas.AddRange(allAchievementDatas.Where(ad => ad.IdUserAchievement == userAchievement.Id));
            }
            List<DetailAchievDataDTO> simpleAchievDataDTOs = achievementDatas.Select(ad => _mapper.Map(ad, new DetailAchievDataDTO())).ToList();
            return simpleAchievDataDTOs;
        }

        public virtual async Task<bool> SaveAchievement(SetUserAchievementDTO setUserAchievementDTO)
        {
            User CurrentUser = (await _unitOfWork.UserRepo.GetAllAsync()).FirstOrDefault(u => u.Email == setUserAchievementDTO.UserEmail);
            Level CurrentLevel = (await _unitOfWork.LevelRepo.GetAllAsync()).FirstOrDefault(l => l.Title == setUserAchievementDTO.LevelTitle);
            if(CurrentUser == null)
            {
                return false;
            }
            UserAchievement userAchievement = (await _unitOfWork.UserAchievementRepo.GetAllAsync()).FirstOrDefault(ua => ua.IdUser == CurrentUser.Id);
            if(userAchievement == null)
            {
                await _unitOfWork.UserAchievementRepo.AddAsync(new UserAchievement {
                    IdUser = CurrentUser.Id,
                    Title = setUserAchievementDTO.Title,
                    Notes = setUserAchievementDTO.Notes,
                    IdLevel = CurrentLevel.Id,
                    SaveDate = DateTime.Now
                });
                AchievementData achievementData = _mapper.Map(setUserAchievementDTO, new AchievementData());
                achievementData.TryCount = 1;
                achievementData.IdUserAchievement = (await _unitOfWork.UserAchievementRepo.GetAllAsync())
                    .FirstOrDefault(ua => ua.IdUser == CurrentUser.Id && ua.IdLevel == CurrentLevel.Id).Id;
                await _unitOfWork.AchievementDataRepo.AddAsync(achievementData);
            }
            else
            {
                userAchievement.Title = setUserAchievementDTO.Title;
                userAchievement.Notes = setUserAchievementDTO.Notes;
                userAchievement.SaveDate = DateTime.Now;
                await _unitOfWork.UserAchievementRepo.UpdateAsync(userAchievement);
                AchievementData achievementData = _mapper.Map(setUserAchievementDTO, new AchievementData());
                achievementData.TryCount = (await _unitOfWork.AchievementDataRepo.GetAllAsync()).Count(ad => ad.IdUserAchievement == userAchievement.Id) + 1;
                achievementData.IdUserAchievement = userAchievement.Id;
                await _unitOfWork.AchievementDataRepo.AddAsync(achievementData);
            }
            return true;
        }
    }
}
