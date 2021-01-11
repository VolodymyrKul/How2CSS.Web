using AutoMapper;
using How2CSS.Core.Abstractions;
using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
using How2CSS.Core.Enums;
using How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs;
using How2CSS.Core.Models;
using How2CSS.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2CSS.Services.Exceptions;

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

        public virtual async Task GenerateAsync(Difficulty difficulty)
        {
            var random = new Random();
            var units = await _unitOfWork.UnitRepo.GetAllAsync();
            var unitIndx = random.Next(units.Count() - 1);
            var unit = units.ToList()[unitIndx];

            var value = new Level();
            var level = await _unitOfWork.LevelRepo.Get().Where(e => e.Title.StartsWith(unit.Name)).OrderBy(e => e.Id).LastOrDefaultAsync();

            int levelIndx;

            if (level != null)
            {
                levelIndx = Int32.Parse(level.Title.Substring(unit.Name.Length + 3)) + 1;
            }
            else
                levelIndx = 1;

            value.Title = $"{unit.Name} - {levelIndx}";
            value.LevelDifficulty = difficulty;

            switch (difficulty)
            {
                case Difficulty.Easy:
                    value.TasksCount = new Random().Next(5, 11);
                    break;
                case Difficulty.Medium:
                    value.TasksCount = new Random().Next(11, 16);
                    break;
                case Difficulty.Hard:
                    value.TasksCount = new Random().Next(16, 21);
                    break;
                default:
                    value.TasksCount = new Random().Next(11, 16); ;
                    break;
            }

            var tasks = await _unitOfWork.CSSTaskRepo.Get()
                .Include(e => e.IdMetadataNavigation)
                .Where(e => e.IdMetadataNavigation.IdUnit == unit.Id)
                .ToListAsync();

            for (int i = 0; i < value.TasksCount; i++)
            {
                int taskIndx;
                TaskDistribution taskDistribution;
                do
                {
                    taskIndx = random.Next(tasks.Count);
                    taskDistribution = new TaskDistribution
                    {
                        IdTask = tasks[taskIndx].Id,
                        TaskOrder = i + 1
                    };
                }
                while (value.TaskDistributions.Where(e=>e.IdTask == taskDistribution.IdTask).FirstOrDefault() != null);

                value.TaskDistributions.Add(taskDistribution);
            }

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

        public virtual async Task<List<LevelTasksDTO>> GetAllDetailed(string email)
        {
            var users = await _unitOfWork.UserRepo.GetAllAsync();
                
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new NotFoundException("User");
            }

            var levels = await _unitOfWork.LevelRepo.GetAllDetailedAsync(user.Id);
            var levelDtos = levels.Select(cSSTask => _mapper.Map(cSSTask, new LevelTasksDTO())).ToList();
            return levelDtos;
        }

        public virtual async Task<LevelDTO> GetIdAsync(int id)
        {
            var level = await _unitOfWork.TaskDistributionRepo.Get()
                .Include(e => e.IdLevelNavigation)
                .Include(e => e.IdTaskNavigation)
                .Include(e => e.IdTaskNavigation.IdQuestionNavigation)
                .Include(e => e.IdTaskNavigation.IdAnswerNavigation)
                .Where(e => e.IdLevel == id).ToListAsync();

            var tasks = level.Select(e => e.IdTaskNavigation);

            if (level == null)
                throw new Exception("Such level not found");

            var dto = new LevelDTO()
            {
                Id = level.First().IdLevel,
                Title = level.First().IdLevelNavigation.Title,
                LevelDifficulty = level.First().IdLevelNavigation.LevelDifficulty,
                TasksCount = level.First().IdLevelNavigation.TasksCount,
                Tasks = _mapper.Map<List<CSSTaskDTOOutput>>(tasks)
            };

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
