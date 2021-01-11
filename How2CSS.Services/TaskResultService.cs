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
