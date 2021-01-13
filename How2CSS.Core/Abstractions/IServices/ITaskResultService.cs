using How2CSS.Core.Abstractions.IServices.Base;
using How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions.IServices
{
    public interface ITaskResultService : IBaseService<TaskResultDTO, TaskResultDTO>
    {
        Task<TaskResultDTO> CreateNewAsync(TaskResultCreateDTO dto);

        Task<TaskResultDTO> EditAsync(TaskResultUpdateDTO dto);
    }
}
