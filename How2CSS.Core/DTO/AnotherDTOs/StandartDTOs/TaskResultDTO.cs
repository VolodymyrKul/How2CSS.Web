using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AnotherDTOs.StandartDTOs
{
    public class TaskResultDTO
    {
        public int Id { get; set; }
        public DateTime ResultDate { get; set; }
        public long Duration { get; set; }
        public string UserAnswer { get; set; }
        public int Score { get; set; }
        public int IdUser { get; set; }
        public int IdTask { get; set; }
    }
}
