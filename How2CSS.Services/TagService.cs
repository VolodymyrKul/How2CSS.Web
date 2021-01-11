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
    public class TagService : BaseService, ITagService
    {
        public TagService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(TagDTO entity)
        {
            var value = new Tag();
            _mapper.Map(entity, value);
            await _unitOfWork.TagRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TagRepo.GetByIdAsync(id);
            await _unitOfWork.TagRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TagDTO>> GetAll()
        {
            var tags = await _unitOfWork.TagRepo.GetAllAsync();
            List<TagDTO> tagDTOs = tags.Select(tag => _mapper.Map(tag, new TagDTO())).ToList();
            return tagDTOs;
        }

        public virtual async Task<TagDTO> GetIdAsync(int id)
        {
            var tag = await _unitOfWork.TagRepo.GetByIdAsync(id);
            if (tag == null)
                throw new Exception("Such order not found");
            var dto = new TagDTO();
            _mapper.Map(tag, dto);
            return dto;
        }

        public virtual async Task<TagDTO> UpdateAsync(TagDTO entity)
        {
            var value = new Tag();
            _mapper.Map(entity, value);
            await _unitOfWork.TagRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
