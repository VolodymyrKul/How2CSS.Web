﻿using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
using How2CSS.Core.Enums;
using System.Collections.Generic;

namespace How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs
{
    public class CSSTaskDetailedDTO
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public Difficulty TaskDifficulty { get; set; }

        public List<TaskResultDTO> TaskResults { get; set; }
    } 
}
