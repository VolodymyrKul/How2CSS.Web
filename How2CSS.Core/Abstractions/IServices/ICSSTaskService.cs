using How2CSS.Core.Abstractions.IServices.Base;
using How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions.IServices
{
    public interface ICSSTaskService : IBaseService<CSSTaskDTO, CSSTaskDTO>
    {
        Task<CSSTaskExecDTO> GetExecAsync(int id);
    }
}
