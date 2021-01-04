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
    public class TagDistributionService : BaseService, ITagDistributionService
    {
        public TagDistributionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(TagDistributionDTO entity)
        {
            var value = new TagDistribution();
            _mapper.Map(entity, value);
            await _unitOfWork.TagDistributionRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TagDistributionRepo.GetByIdAsync(id);
            await _unitOfWork.TagDistributionRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TagDistributionDTO>> GetAll()
        {
            var tagDistributions = await _unitOfWork.TagDistributionRepo.GetAllAsync();
            List<TagDistributionDTO> tagDistributionDTOs = tagDistributions.Select(tagDistribution => _mapper.Map(tagDistribution, new TagDistributionDTO())).ToList();
            return tagDistributionDTOs;
        }

        public virtual async Task<TagDistributionDTO> GetIdAsync(int id)
        {
            var tagDistribution = await _unitOfWork.TagDistributionRepo.GetByIdAsync(id);
            if (tagDistribution == null)
                throw new Exception("Such order not found");
            var dto = new TagDistributionDTO();
            _mapper.Map(tagDistribution, dto);
            return dto;
        }

        public virtual async Task<TagDistributionDTO> UpdateAsync(TagDistributionDTO entity)
        {
            var value = new TagDistribution();
            _mapper.Map(entity, value);
            await _unitOfWork.TagDistributionRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
