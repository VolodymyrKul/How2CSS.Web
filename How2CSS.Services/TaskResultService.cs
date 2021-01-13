using AutoMapper;
using How2CSS.Core.Abstractions;
using How2CSS.Core.Abstractions.IServices;
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
    }
}
