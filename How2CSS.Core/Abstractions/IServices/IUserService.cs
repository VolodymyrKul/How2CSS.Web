﻿using How2CSS.Core.Abstractions.IServices.Base;
using How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using How2CSS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions.IServices
{
    public interface IUserService : IBaseService<UserDTO, SignUpDTO>
    {
        Task<bool> LoginAsync(SignInDTO entity);
        Task<bool> SearchAsync(string email);
        Task<UserDTO> GetProfileInfo(string email);
    }
}
