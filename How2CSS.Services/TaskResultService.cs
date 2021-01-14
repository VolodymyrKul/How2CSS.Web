using AutoMapper;
using How2CSS.Core.Abstractions;
using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
using How2CSS.Core.Models;
using How2CSS.Services.Base;
using How2CSS.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Services
{
    public class TaskResultService : BaseService, ITaskResultService
    {
        public TaskResultService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(TaskResultDTO entity)
        {
            var value = new TaskResult();
            _mapper.Map(entity, value);
            await _unitOfWork.TaskResultRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task<TaskResultDTO> CreateNewAsync(TaskResultCreateDTO dto)
        {
            var users = await _unitOfWork.UserRepo.GetAllAsync();

            var user = users.FirstOrDefault(u => u.Email == dto.UserEmail);
            if (user == null)
            {
                throw new NotFoundException("User");
            }

            var entity = _mapper.Map<TaskResult>(dto);
            entity.ResultDate = DateTime.Now;
            entity.IdUser = user.Id;
            entity.Score = 0;
            entity.UserAnswer = "";
            entity.Duration = 0;
            await _unitOfWork.TaskResultRepo.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TaskResultDTO>(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TaskResultRepo.GetByIdAsync(id);
            await _unitOfWork.TaskResultRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TaskResultDTO>> GetAll()
        {
            var taskResults = await _unitOfWork.TaskResultRepo.GetAllAsync();
            List<TaskResultDTO> taskResultDTOs = taskResults.Select(taskResult => _mapper.Map(taskResult, new TaskResultDTO())).ToList();
            return taskResultDTOs;
        }

        public virtual async Task<TaskResultDTO> GetIdAsync(int id)
        {
            var taskResult = await _unitOfWork.TaskResultRepo.GetByIdAsync(id);
            if (taskResult == null)
                throw new Exception("Such order not found");
            var dto = new TaskResultDTO();
            _mapper.Map(taskResult, dto);
            return dto;
        }

        public virtual async Task<TaskResultDTO> EditAsync(TaskResultUpdateDTO dto)
        {
            var taskResult = await _unitOfWork.TaskResultRepo.GetByIdAsync(dto.Id);
            if (taskResult == null)
                throw new NotFoundException("TaskResult", dto.Id);

            taskResult.Duration = dto.Duration;
            taskResult.Score = dto.Score;
            taskResult.UserAnswer = dto.UserAnswer;

            await _unitOfWork.TaskResultRepo.UpdateAsync(taskResult);
            await _unitOfWork.SaveChangesAsync();

            await GetDataForSaveAchiev(taskResult);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TaskResultDTO>(taskResult);
        }

        public virtual async Task<TaskResultDTO> UpdateAsync(TaskResultDTO entity)
        {
            var value = new TaskResult();
            _mapper.Map(entity, value);
            await _unitOfWork.TaskResultRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task GetDataForSaveAchiev(TaskResult taskResult)
        {
            var taskDists = await _unitOfWork.TaskDistributionRepo.GetAllAsync();
            var taskResults = await _unitOfWork.TaskResultRepo.GetAllAsync();
            var levels = taskDists.Where(td => td.IdTask == taskResult.IdTask).Select(td => td.IdLevel);
            foreach(int level in levels)
            {
                var tasksCount = (await _unitOfWork.LevelRepo.GetByIdAsync(level)).TasksCount;
                SetUserAchievementDTO userAchiev = new SetUserAchievementDTO() { 
                    IdLevel = level, 
                    IdUser = taskResult.IdUser, 
                    CompletedCount = 0, 
                    CorrectCount = 0, 
                    CurrentMark = 0, 
                    Title = "Empty", 
                    Notes = "Empty" };
                var tasks = taskDists.Where(td => td.IdLevel == level).Select(td => td.IdTask);

                foreach(var task in tasks)
                {
                    var searchRes = taskResults.FirstOrDefault(tr => tr.IdTask == task);
                    if (searchRes != null)
                    {
                        userAchiev.CompletedCount++;
                        userAchiev.CurrentMark += searchRes.Score;
                        if (searchRes.Score == 100)
                        {
                            userAchiev.CorrectCount++;
                        }
                    }
                }
                if(tasksCount != 0)
                {
                    userAchiev.CurrentMark /= tasksCount;
                }
                await SaveAchievement(userAchiev);
            }
        }

        public async Task<bool> SaveAchievement(SetUserAchievementDTO setUserAchievementDTO)
        {
            UserAchievement userAchievement = (await _unitOfWork.UserAchievementRepo.GetAllAsync()).FirstOrDefault(ua => ua.IdUser == setUserAchievementDTO.IdUser && ua.IdLevel == setUserAchievementDTO.IdLevel/*CurrentUser.Id*/);
            if (userAchievement == null)
            {
                await _unitOfWork.UserAchievementRepo.AddAsync(new UserAchievement
                {
                    IdUser = setUserAchievementDTO.IdUser,
                    Title = setUserAchievementDTO.Title,
                    Notes = setUserAchievementDTO.Notes,
                    IdLevel = setUserAchievementDTO.IdLevel,
                    SaveDate = DateTime.Now
                });
                AchievementData achievementData = _mapper.Map(setUserAchievementDTO, new AchievementData());
                achievementData.TryCount = 1;
                achievementData.IdUserAchievement = (await _unitOfWork.UserAchievementRepo.GetAllAsync())
                    .FirstOrDefault(ua => ua.IdUser == setUserAchievementDTO.IdUser && ua.IdLevel == setUserAchievementDTO.IdLevel/*CurrentLevel.Id*/).Id;
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
